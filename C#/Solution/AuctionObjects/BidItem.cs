using System;

namespace Czf.Domain.AuctionObjects
{
	public class BidItem
	{
		#region private
		private List<Bid> _itemBids;
		#endregion
		
		#region Properties
		public Bid? CurrentBid 
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
		[NonSerialized]
		public List<Bid> ItemBids
		{
			get
			{
				if(_itemBids == null)
				{
					_itemBids = AuctionSource.GetRelatedById<Bid,AuctionItem>(Id);
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

