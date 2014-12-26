using System;
using System.Web.Mvc;
using Elmah.ContentSyndication;
using Czf.App.WebAuction.Models;
using Czf.Domain.AuctionObjects;
namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Description of ItemController.
	/// </summary>
	public class ItemController : GlobalAuctionController
	{
		
		/// <summary>
		/// Action to setup Item display data for view
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Item(int id)
		{
			ActionResult result = null;
			ItemViewModel model = new ItemViewModel();
			BidItem item = AuctionSource.Get<BidItem>(id);
			if(item != null)
			{
				model.Item = item;
				result = View(ViewName.Item.FullView.Item, model);
			}
			else
			{
				result = RedirectToAction("Silent",ControllerName.ItemList);
			}
			return result;
			
		}
	}
}