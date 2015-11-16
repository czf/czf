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
using System.Net;
using System.Web.Http.Results;
namespace InventoryAPI.Tests.Controllers
{
	[TestFixture]
	public class InventoryItemApiTest
	{
		private TestServer server;

		[SetUp]
		public void Setup()
		{
			server = TestServer.Create<Startup>();
		}

		[TearDown]
		public void TearDown()
		{
			server.Dispose();
			server = null;
		}
		[Test]
		public void ShouldReturnBadRequestOnNullLabelPost()
		{
			Task<HttpResponseMessage> response = server.CreateRequest("/InventoryItemQuery").PostAsync();


			response.Wait();
			HttpResponseMessage result = response.Result;

			Assert.IsFalse(result.IsSuccessStatusCode);
			Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

		}


		[Test]
		public void ShouldReturnBadRequestOnEmptyPost()
		{
			Task<HttpResponseMessage> response = server.CreateRequest("/InventoryItem").PostAsync();
			response.Wait();
			HttpResponseMessage result = response.Result;

			Assert.IsFalse(result.IsSuccessStatusCode);
			Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
			
		}

		


	}
}
