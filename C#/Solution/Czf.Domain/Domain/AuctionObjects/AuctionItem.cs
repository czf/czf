/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/15/2012
 * Time: 3:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Czf.Domain.BaseClasses;
using Czf.Domain.Interfaces;
using Czf.Interfaces.Sources;

namespace Czf.Domain.AuctionObjects
{
	/// <summary>
	/// Description of AuctionItem.
	/// </summary>
	public class AuctionItem : IdentifiedByInt
	{
		#region private
		private List<Bid> _itemBids;
		#endregion
		
		#region properties
		public string Title {get; set;} 
		
		public string descriptoin {get; set;} 
		
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
		
		public IAuctionSource AuctionSource {get; set;} 
		#endregion
		
		#region constructors
		public AuctionItem()
		{
		}
		#endregion
		
		#region methods
		#endregion
		
		
	}
}
