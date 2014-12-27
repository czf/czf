/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/26/2014
 * Time: 4:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.Global;
using Czf.Domain.Interfaces.Consumers;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.BaseClasses;
namespace Czf.App.WebAuction.Models.InputViewModel
{
	/// <summary>
	/// Description of BidActionInputModel.
	/// </summary>
	public class BidActionInputModel : IAuctionSourceConsumer
	{
		#region Privates
		#endregion
		#region Properties
		/// <summary>
		/// The amount submitted for a bid.
		/// </summary>
		public decimal? BidAmountSubmitted {get; set;}
		
		/// <summary>
		/// The Item this bid is for.
		/// </summary>
		public int? ItemId {get; set;}
		
		/// <summary>
		/// A reference to the AuctionSource
		/// </summary>
		public IAuctionSource AuctionSource {get; set;}
		
		/// <summary>
		/// Populated by CheckValidity this is the item the bid was submited for.
		/// </summary>
		public BaseAuctionItem Item {get; protected set;}
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of BidActionInputModel.
		/// </summary>
		public BidActionInputModel()
		{}
		#endregion
		#region Methods
		/// <summary>
		/// Determines if the ItemId is for a valid BaseAuctionItem and if the bidAmountSubmitted is not null.
		/// </summary>
		/// <returns></returns>
		public bool CheckValidity()
		{
			//TODO Error/warning Messages
			
			bool result = false;
			if(ItemId.HasValue)
			{
				Item = AuctionSource.Get<BaseAuctionItem>(ItemId.Value);
			}
			
			if(Item != null && Item.Status == AuctionItemStatus.Active)
			{
				result = BidAmountSubmitted.HasValue;
			}
			return result;
			
		}
		#endregion
	}
}
