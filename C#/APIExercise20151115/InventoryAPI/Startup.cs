using Hangfire;
using Microsoft.Owin;
using Owin;
using Hangfire.MemoryStorage;
using Czf.Domain.Interfaces;
using Czf.Domain;
using InventoryAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Diagnostics;
[assembly: OwinStartup(typeof(InventoryAPI.Startup))]

namespace InventoryAPI
{
	/// <summary>
	/// Startup class for owin
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Configuration class for owin
		/// </summary>
		/// <param name="app"></param>
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			
			Hangfire.GlobalConfiguration.Configuration.UseMemoryStorage();
			app.UseHangfireDashboard();
			app.UseHangfireServer();

			app.UseErrorPage(new ErrorPageOptions()
			{
				//Shows the OWIN environment dictionary keys and values. This detail is enabled by default if you are running your app from VS unless disabled in code. 
				ShowEnvironment = true,
				//Hides cookie details
				ShowCookies = false,
				//Shows the lines of code throwing this exception. This detail is enabled by default if you are running your app from VS unless disabled in code. 
				ShowSourceCode = true,
			});
			config.MapHttpAttributeRoutes();
			app.UseWebApi(config);

			//Recurring job for finding expired items
			RecurringJob.AddOrUpdate(() => CreateExpiredNotifications(), Cron.Daily);
		}
		/// <summary>
		/// finds the InventoryItems that have expired since the last check and creates notifications for them.
		/// </summary>
		public static void CreateExpiredNotifications()
		{
			IRepository Repository = BaseController.GetRepository();
			ExpiredInventoryItemNotificationDate date =
				Repository.Get<ExpiredInventoryItemNotificationDate>(ExpiredInventoryItemNotificationDate.LOOKUPKEY_last);
			List<InventoryItem> expiredItems = Repository.Search<InventoryItem>(InventoryItem.SEARCHMETHOD_ExpiredSince,
				(date ?? new ExpiredInventoryItemNotificationDate() { Date = DateTime.MinValue }).Date);

			foreach (string note in expiredItems.Select(x => "Item Expired, Id: " + x.Id + " Label: " + x.Label))
			{
				Repository.Add<Notification>(note);
			}
			Repository.Add<ExpiredInventoryItemNotificationDate>(new ExpiredInventoryItemNotificationDate() { Date = DateTime.Now });

		}
	}
}