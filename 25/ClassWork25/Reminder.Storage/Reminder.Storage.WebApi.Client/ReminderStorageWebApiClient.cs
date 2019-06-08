using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Reminder.Storage.WebApi.Client
{
	public class ReminderStorageWebApiClient : IReminderStorage
	{
		private string _baseWebApiUrl;
		private HttpClient _httpClient;

		public ReminderStorageWebApiClient(string baseWebApiUrl)
		{
			_baseWebApiUrl = baseWebApiUrl;
			_httpClient = HttpClientFactory.Create();
		}

		public Guid Add(ReminderItemRestricted reminder)
		{

			var result = CallWebApi("POST", "/api/reminders", JsonConvert.SerializeObject(new ReminderItemCreateModel(reminder)));

			if (result.StatusCode !=System.Net.HttpStatusCode.Created)
			{
				throw CreateException(result);
			}

			string content = result.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<ReminderItemGetModel>(content).Id;
		}

		public ReminderItemResricted Get(Guid id)
		{
			var result = CallWebApi("GET", $"/api/reminders/{id}");

			string content = result.Content.ReadAsStringAsync().Result;
			
			if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return null;
			}

			if (result.StatusCode != System.Net.HttpStatusCode.OK)
			{
				throw CreateException(result);
			}

			return JsonConvert.DeserializeObject<ReminderItemGetModel>(content).ToReminderItem();
		}

		public List<ReminderItemResricted> Get(ReminderItemStatus status)
		{
			var result = CallWebApi("GET", $"/api/reminders/[filter]status={(int)status}");

			string content = result.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(content)
				.Select(x => x.ToReminderItem())
				.ToList();
		}

		public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
		{
			var patchDocument = new JsonPatchDocument<ReminderItemUpdateModel>(new List<Operation<ReminderItemUpdateModel>>
			{
				new Operation<ReminderItemUpdateModel>
				{
					op = "replace",
					path = "/status",
					value = (int)status
				}
			},

			new Newtonsoft.Json.Serialization.DefaultContractResolver());

			var model = new ReminderItemsUpdateModel
			{
				Ids = ids.ToList(),
				PatchDocument = patchDocument
			};

			var content = JsonConvert.SerializeObject(model);

			var result = CallWebApi("PATCH", "/api/reminders", content);

			if (result.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				throw CreateException(result);
			}
		}

		public void UpdateStatus(Guid id, ReminderItemStatus status)
		{
			var patchDocument = new JsonPatchDocument<ReminderItemUpdateModel>(new List<Operation<ReminderItemUpdateModel>>
			{
				new Operation<ReminderItemUpdateModel>
				{
					op = "replace",
					path = "/status",
					value = (int)status
				}
			},

			new Newtonsoft.Json.Serialization.DefaultContractResolver());

			var content = JsonConvert.SerializeObject(patchDocument);

			var result = CallWebApi("PATCH", "/api/reminders", content);

			if (result.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				throw CreateException(result);
			}

		}

		private HttpResponseMessage CallWebApi(string method, string relativeUrl, string content = null)
		{
			var request = new HttpRequestMessage(new HttpMethod(method),
				_baseWebApiUrl + relativeUrl);

			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			if (method == "POST" || method == "PATCH" || method == "PUT")
			{
				request.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
			}

			return _httpClient.SendAsync(request).Result;
		}

		private Exception CreateException(HttpResponseMessage httpResponseMessage)
		{
				return new Exception($"Error: {httpResponseMessage.StatusCode}, " +
					$"Content: {httpResponseMessage.Content.ReadAsStringAsync().Result}");
		}
	}
}
