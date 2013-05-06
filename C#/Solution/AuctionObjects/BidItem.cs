using System;
using System.Collections.Generic;
using Czf.Domain.BaseClasses;
using Czf.Domain.Interfaces.Consumers;
using Czf.Domain.Interfaces.Sources;

namespace Czf.Domain.AuctionObjects
{
	public class BidItem : IdentifiedByInt, IAuctionSourceConsumer
	{
		#region private
		private List<Bid> _itemBids;
		#endregion
		
		#region Properties
		/// <summary>
		/// Get data relating to auctions
		/// </summary>
		public IAuctionSource AuctionSource {get; set;} 
		
		public Bid CurrentBid 
		{
			get
			{
				if(ItemBids != null)
				{
					ItemBids.Sort();
					return ItemBids[ItemBids.Count-1];
				}
				return null;
			}
		}
		

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
		
	}
}

