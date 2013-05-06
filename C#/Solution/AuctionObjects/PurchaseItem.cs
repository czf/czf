/*
 * Created by MonoDevelop
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
using Czf.Domain.Interfaces.Sources;

/// <summary>
/// Purchase item.  Items that are not bid on but bought as a group.  Bid-o-gram doesn't acutally have these.
/// </summary>

namespace Czf.Domain.AuctionObjects
{
	
	public class PurchaseItem : BaseAuctionItem
	{
		private int QuantityOverride {get; set;}
		
		public int QuantityAvailable {get; set;}

		public double Price {get; set;}
		
		
		
		public PurchaseItem ()
		{
		}
	}
}

