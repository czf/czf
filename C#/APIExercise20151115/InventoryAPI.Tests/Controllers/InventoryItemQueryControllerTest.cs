using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using NUnit.Framework;
using System.Web.Http;
using Microsoft.Owin.Testing;
using InventoryAPI;
using InventoryAPI.Controllers;
using Czf.Domain;
using Czf.Domain.InputModel;
using Czf.Domain.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using Czf.Repositories;
using System.Web.Http.Results;
namespace InventoryAPI.Tests.Controllers
{
	[TestFixture]
	class InventoryItemQueryControllerTest
	{
		private InventoryItemQueryController InventoryItemQueryController;
		private InMemoryRepository Repository;
		[SetUp]
		public void Setup()
		{
			InventoryItemQueryController = new InventoryItemQueryController();
			InventoryItemQueryController.Request = new HttpRequestMessage();
			InventoryItemQueryController.Configuration = new HttpConfiguration();
			Repository = (InMemoryRepository)InventoryItemQueryController.Repository;
			Repository.Reset();
		}

		[Test]
		public void ShouldRemoveInventoryItemOnRetrieve()
		{
			DateTime date = DateTime.Now.AddDays(365);
			string label = "Label Data";
			int id = -1;
			Repository.Items.Add(new InventoryItem(id, label, date));

			OkNegotiatedContentResult<InventoryItem> result = InventoryItemQueryController.Query(label) as OkNegotiatedContentResult<InventoryItem>;
			
			Assert.NotNull(result);
			Assert.NotNull(result.Content);
			Assert.That(!Repository.Items.Any());
		}


		[Test]
		public void ShouldAddNotificationOnRetrieve()
		{
			DateTime date = DateTime.Now.AddDays(365);
			string label = "Label Data";
			int id = -1;
			Repository.Items.Add(new InventoryItem(id, label, date));

			OkNegotiatedContentResult<InventoryItem> result = InventoryItemQueryController.Query(label) as OkNegotiatedContentResult<InventoryItem>;


			Assert.NotNull(result);
			Assert.NotNull(result.Content);
			Assert.That(result.Content.ExpirationDate, Is.EqualTo(date));
			Assert.That(result.Content.Label, Is.EqualTo(label));
			Assert.That(result.Content.Id, Is.EqualTo(id));
			Assert.That(Repository.Notifications.Any(x => x.Message.Contains("ItemId: " + result.Content.Id)));
		}
	}
}
