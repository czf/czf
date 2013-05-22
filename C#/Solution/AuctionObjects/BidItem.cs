using System;
using System.Collections.Generic;
using Czf.Domain.BaseClasses;
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
					return ItemBids.Where(ib => !ib.Canceled).OrderBy(ib => ib.Amount).First();;
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
		
		bool Save()
		{
			return AuctionSource.Save(this);
		}
		
		#endregion
		
		
		
	}
}

