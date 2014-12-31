/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/14/2014
 * Time: 5:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects;
using System.Linq;
using Czf.Domain.Global;
using System.Collections.Generic;
namespace Czf.Sources.AuctionSource
{
	/// <summary>
	/// Description of BidItemStubHelper.
	/// </summary>
	internal class BidItemStubHelper
	{
		#region Privates
		private readonly StubAuctionSource AuctionSource;
		#endregion
		#region Properties 
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of BidItemStubHelper.
		/// </summary>
		public BidItemStubHelper(StubAuctionSource source)
		{
			AuctionSource = source;
			AuctionSource._domainDictionay.Add(typeof(BidItem),new Dictionary<int,object>());
			AuctionSource._domainDictionay[typeof(BidItem)].Add(1,
			                                      	new BidItem{
			                                      	Id = 1,
			                                      	AuctionSource = AuctionSource,	
			                                      	Description = "A widget that widgets.",
			                                      	Title = "widget 1",
			                                      	Value = 100,
				                                    SortOrder = 2,
				                                    Status = AuctionItemStatus.Active
			                                      });
			AuctionSource._domainDictionay[typeof(BidItem)].Add(2,
			                                      	new BidItem{
			                                      	Id = 2,
			                                      	AuctionSource = AuctionSource,	
			                                      	Description = "A do something that somethings.",
			                                      	Title = "do something 1",
			                                      	Value = 101,
			                                      	SortOrder = 3
			                                      });
		}
		#endregion
		#region Methods
		#endregion
	}
}
