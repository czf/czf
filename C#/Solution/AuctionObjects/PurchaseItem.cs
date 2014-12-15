/*
 * Created by SharpDevelop
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



namespace Czf.Domain.AuctionObjects
{
	/// <summary>
	/// Purchase item.  Items that are not bid on but bought as a group. 
	/// </summary>
	public class PurchaseItem : BaseAuctionItem
	{
		#region Privates
		private int QuantityOverride {get; set;} //Not sure why this is private
		private List<User> _usersPurchased;
		#endregion
		#region Properties
		/// <summary>
		/// Number of this Item available for purchase
		/// </summary>
		public int QuantityAvailable {get; set;}
		
		/// <summary>
		/// Price this 
		/// </summary>
		public decimal Price {get; set;}
		
		/// <summary>
		/// Returns the users that have purchased this.
		/// </summary>
		public List<User> UsersPurchased 
		{
			get
			{
				if(_usersPurchased == null)
				{
					_usersPurchased = AuctionSource.GetRelatedById<User,PurchaseItem>(Id.Value);
				}
				return _usersPurchased;
			}
		}
		#endregion
		#region Constructors
		
		/// <summary>
		/// create an instance of PurchaseItem
		/// </summary>
		public PurchaseItem ()
		{
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Allows a users to purchase this item
		/// </summary>
		/// <param name="user"></param>
		/// <returns>True if successfully purchased. False otherwise.</returns>
		public bool Purchase(User user)
		{
			bool result = false;
			if (QuantityAvailable > 0)
			{
				QuantityAvailable--;
				UsersPurchased.Add(user);
				if(!Save())
				{
					QuantityAvailable ++;
					UsersPurchased.Remove(user);
				}
				else
				{
//					Bid purchaseBid = AuctionSource.Create<Bid>();
//					purchaseBid.Amount = Price;
//					purchaseBid.BidUser =user;
					result = true;
				}
			}
			return result;
		}
		/// <summary>
		/// Saves this instance to the AuctionSource
		/// </summary>
		/// <returns>true if successfully saved</returns>
		public override bool Save()
		{
			return AuctionSource.Save<PurchaseItem>(this);
		}
		#endregion
	}
}

