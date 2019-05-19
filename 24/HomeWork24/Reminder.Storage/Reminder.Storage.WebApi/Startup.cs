using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace Reminder.Storage.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddSingleton<IReminderStorage>(new InMemoryReminderStorage());

            var storage = new InMemoryReminderStorage();
            storage.Add(new ReminderItem
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                Date = DateTimeOffset.Now.AddMinutes(1),
                ContactId = "TestContactId",
                Message = "Testmessage",
                Status = ReminderItemStatus.Ready
            });

            storage.Add(new ReminderItem
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                ContactId = "TestContactId1",
                Date = DateTimeOffset.Now,
                Message = "Test message1",
                Status = ReminderItemStatus.Ready
            });

            storage.Add(new ReminderItem
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                ContactId = "TestContactId2",
                Date = DateTimeOffset.Now,
                Message = "Test message2",
                Status = ReminderItemStatus.Sent
            });

            services.AddSingleton<IReminderStorage>(storage);
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseMvc();
		}
	}
}
