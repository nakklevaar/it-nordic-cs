using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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

		public void Add(ReminderItem reminder)
		{
			string method = "POST";
			string relativeUrl = "/api/reminders";
			string content = JsonConvert.SerializeObject(new ReminderItemCreateModel(reminder));

			var request = new HttpRequestMessage(new HttpMethod(method),
				_baseWebApiUrl+relativeUrl);

			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

			request.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

			var result = _httpClient.SendAsync(request).Result;

			if (result.StatusCode !=System.Net.HttpStatusCode.Created)
			{
				throw new Exception($"Error: {result.StatusCode}, " +
					$"Content: {result.Content.ReadAsStringAsync().Result}");
			}
		}

		public ReminderItem Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			throw new NotImplementedException();
		}

		public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
		{
			throw new NotImplementedException();
		}

		public void UpdateStatus(Guid id, ReminderItemStatus status)
		{
			throw new NotImplementedException();
		}
	}
}
