using System;
using System.Web.Mvc;
using Czf.Domain.Interfaces.Consumers;
using Czf.Domain.Interfaces.Sources;
namespace Czf.Mvc.Common.Controllers
{
	/// <summary>
	/// Description of BaseAuctionController.
	/// </summary>
	public abstract class BaseAuctionController : Controller, IAuctionSourceConsumer
	{
		public IAuctionSource AuctionSource {get; set;}
	}
}