/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/14/2014
 * Time: 5:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects;
using System.Collections.Generic;
using System.Linq;
namespace Czf.Sources.AuctionSource
{
	/// <summary>
	/// Description of BidStubHelper.
	/// </summary>
	internal class BidStubHelper
	{
		#region Privates
		private readonly StubAuctionSource AuctionSource;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public BidStubHelper(StubAuctionSource source)
		{
			AuctionSource = source;
			AuctionSource._domainDictionay.Add(typeof(Bid),new Dictionary<int,object>());
		}
		#endregion
	}
}
