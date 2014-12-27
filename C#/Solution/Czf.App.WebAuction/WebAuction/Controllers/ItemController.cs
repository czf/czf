using System;
using System.Web.Mvc;
using Elmah.ContentSyndication;
using Czf.App.WebAuction.Models;
using Czf.App.WebAuction.Models.InputViewModel;
using Czf.Domain.AuctionObjects;
using Czf.Domain.BaseClasses;
using Czf.Mvc.Common.ActionFilters;
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
		[HttpGet]
		public ActionResult Item(int id)
		{
			ActionResult result = null;
			ItemViewModel model = new ItemViewModel();
			BidItem item = AuctionSource.Get<BidItem>(id);
			if(item != null)
			{
				model.Item = item;
				model.Input.ItemId = item.Id;
				result = View(ViewName.Item.FullView.Item, model);
			}
			else
			{
				result = RedirectToAction("Silent",ControllerName.ItemList);
			}
			return result;
		}
		/// <summary>
		/// Processes a submitted bid for an auction item.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[SetInputSources]
		[HttpPost]
		public ActionResult SubmitBid(BidActionInputModel input)
		{
			ActionResult result;
		
			if(AuctionSession.User == null)
			{
				result = RedirectToAction("Index",ControllerName.Login);
			}
			else
			{
				if(input.CheckValidity())
				{
					input.Item.AddBid(AuctionSession.User, input.BidAmountSubmitted.Value);
					result = RedirectToAction("Item",new {id = input.ItemId});
				}
				else if(input.Item != null)
				{
					ItemViewModel model = new ItemViewModel();
					model.Input= input;
					model.Item = input.Item;
					result = View(ViewName.Item.FullView.Item,model);
				}
				else
				{
					result = RedirectToAction("Silent", ControllerName.ItemList);
				}
			}
			return result;
		}
	}
}