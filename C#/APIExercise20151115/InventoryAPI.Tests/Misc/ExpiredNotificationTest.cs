using System;
using Czf.Domain;
using Czf.Repositories;
using InventoryAPI.Controllers;
using NUnit.Framework;
namespace InventoryAPI.Tests.Misc
{
	[TestFixture]
	class ExpiredNotificationTest
	{
		private InMemoryRepository Repository;

		[SetUp]
		public void Setup()
		{
			Repository = (InMemoryRepository)BaseController.GetRepository();
			Repository.Reset();
		}

		[Test]
		public void ShouldAddExpiredItemNotification()
		{
			Repository.Items.Add(new InventoryItem(-1, "label data", DateTime.Now.AddDays(-5)));
			Startup.CreateExpiredNotifications();
			Assert.IsNotEmpty(Repository.Notifications);
			Assert.That(Repository.Notifications.Count, Is.EqualTo(1));
		}

		[Test]
		public void ShouldNotAddExpiredItemNotifiation()
		{
			Repository.Items.Add(new InventoryItem(-1, "label data", DateTime.Now.AddDays(-5)));
			Repository.ExpiredInventoryItemNotificationDates.Add(new ExpiredInventoryItemNotificationDate() { Date = DateTime.Now });
			Startup.CreateExpiredNotifications();
			Assert.IsEmpty(Repository.Notifications);
		}

		[Test]
		public void ShouldNotAddDuplicateExpiredItemNotification()
		{
			Repository.Items.Add(new InventoryItem(-1, "label data", DateTime.Now.AddDays(-5)));
			Startup.CreateExpiredNotifications();
			Assert.IsNotEmpty(Repository.Notifications);
			Assert.That(Repository.Notifications.Count, Is.EqualTo(1));
			Startup.CreateExpiredNotifications();
			Assert.That(Repository.Notifications.Count, Is.EqualTo(1));
		}
	}
}
