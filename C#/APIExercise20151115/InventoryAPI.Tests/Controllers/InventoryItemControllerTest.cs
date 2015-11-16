using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Czf.Domain;
using Czf.Domain.InputModel;
using Czf.Repositories;
using InventoryAPI.Controllers;
using NUnit.Framework;

namespace InventoryAPI.Tests.Controllers
{
	[TestFixture]
	class InventoryItemControllerTest
	{
		private InventoryItemController InventoryItemController;
		private InMemoryRepository Repository;
		[SetUp]
		public void Setup()
		{
			InventoryItemController = new InventoryItemController();
			InventoryItemController.Request = new HttpRequestMessage();
			InventoryItemController.Configuration = new HttpConfiguration();
			Repository = (InMemoryRepository)InventoryItemController.Repository;
		}

		[Test]
		public void ShouldAddInventoryItem()
		{
			DateTime date = DateTime.Now.AddDays(365);
			string label = "Label Data";
            InventoryItemInputModel model = new InventoryItemInputModel()
			{
				ExpirationDate = date,
				Label = label
			};
			
			OkNegotiatedContentResult<InventoryItem> result = InventoryItemController.Post(model) as OkNegotiatedContentResult<InventoryItem>;

			Assert.NotNull(result);
			Assert.NotNull(result.Content);
			Assert.That(result.Content.ExpirationDate, Is.EqualTo(date));
			Assert.That(result.Content.Label, Is.EqualTo(label));
			Assert.That(Repository.Items.Any(x => x.ExpirationDate == date && x.Label == label));
        }

		

	
	}
}
