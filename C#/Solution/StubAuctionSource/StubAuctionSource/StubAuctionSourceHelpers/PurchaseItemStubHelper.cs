/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/14/2014
 * Time: 8:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Czf.Domain.AuctionObjects;
namespace Czf.Sources.AuctionSource
{
	/// <summary>
	/// Description of PurchaseItemStubHelper.
	/// </summary>
	public class PurchaseItemStubHelper
	{
		#region Privates
		private readonly StubAuctionSource AuctionSource;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of PurchaseItemStubHelper.
		/// </summary>
		public PurchaseItemStubHelper(StubAuctionSource source)
		{
			AuctionSource = source; 
			AuctionSource._domainDictionay = new Dictionary<Type, Dictionary<int, object>>();
			AuctionSource._domainDictionay[typeof(PurchaseItem)].Add(3,
			                                                     new PurchaseItem{
			                                                     Id = 3,
			                                                     AuctionSource = AuctionSource,
			                                                     Price = 10.00m,
			                                                     Description = "Poker night for the group hosted by some person.",
			                                                     Title = "Poker night",
			                                                     QuantityAvailable = 5,
			                                                         });
			                                                         
		}
		#endregion
		#region Methods
		#endregion
	}
}
