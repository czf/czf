using System;
using System.Collections.Generic;
using Czf.Domain.AuctionObjects;
using Czf.Domain.BaseClasses;
using Czf.Domain.Global;
using Czf.Domain.Interfaces.Consumers;
using Czf.Domain.Interfaces.Sources;
using System.Linq;
namespace Czf.Domain.AuctionObjects
{
	public class BidItem : BaseAuctionItem
	{
		#region private
		private List<Bid> _itemBids;
		#endregion
		
		#region Properties
		
		
		/// <summary>
		/// The highest valued bid that is not Canceled
		/// </summary>
		public Bid CurrentBid 
		{
			get
			{
				//TODO: Refactor to allow for a bid that isn't the highest to be allowed
				if(ItemBids != null)
				{
					return ItemBids.Where(ib => !ib.Canceled).OrderBy(ib => ib.Amount).FirstOrDefault();;
				}
				return null;
			}
		}
		

		/// <summary>
		/// All bids, whether cancelled or not cancelled, for the BidItem.
		/// </summary>
		public List<Bid> ItemBids
		{
			get
			{
				if(_itemBids == null && Id.HasValue)
				{
					_itemBids = AuctionSource.GetRelatedById<Bid,BidItem>(Id.Value);
				}
				return _itemBids;
			}
		}
		
		
		#endregion
		
		#region Constructors
		public BidItem ()
		{
		}
		#endregion
		
		#region Methods
		public override void AddBid(User user, decimal amount)
		{
			BidOnThis(user, amount);
		}
		
		/// <summary>
		/// Allows for bidding on a BidItem.
		/// </summary>
		/// <param name="user"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		/// <returns>false when can't access bid data or update bid. Higestbid is the the highest valid bid or null if no bid.</returns>
		public void BidOnThis(User user, decimal amount) 
		{
			Bid bid = AuctionSource.Create<Bid>();
			bid.Amount = amount;
			bid.BidUser = user;
			bid.DateMade = DateTime.Now;
			bid.ItemIdForBid = Id.Value;
			if(bid.Save())
			{
				ItemBids.Add(bid);
			}
		}	
		
		public override bool Save()
		{
			return AuctionSource.Save(this);
		}
		
		#endregion
		
		
		
	}
}

