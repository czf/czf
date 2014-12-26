using System;
using System.Web.Mvc;

using Czf.App.WebAuction;
using Czf.App.WebAuction.Models;
using Czf.Domain.AuctionObjects;
namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Description of ItemListController.
	/// </summary>
	public class ItemListController : GlobalAuctionController
	{
		/// <summary>
		/// Action for the slient auction
		/// </summary>
		/// <returns></returns>
		public ActionResult Silent()
		{
			ItemListViewModel model = new ItemListViewModel();
			model.AuctionItems.AddRange(AuctionSource.GetAll<BidItem>());
			return View(ViewName.ItemList.FullView.List, model);
			
		}
		
		
		/// <summary>
		/// Action for the Secondary auction during the live auction
		/// </summary>
		/// <returns></returns>
		public ActionResult Secondary()
		{
			return View();
		}
	}
}