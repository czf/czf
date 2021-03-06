﻿/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/15/2012
 * Time: 3:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.BaseClasses;
using Czf.Domain.GenericObjects;
using System.Collections.Generic;
namespace Czf.Domain.AuctionObjects
{
	/// <summary>
	/// Description of User.
	/// </summary>
	public class User : IdentifiedByInt
	{
		#region Privates
		[NonSerialized]
		private List<Bid> _userBids = null;
		#endregion

		#region Constants
		/// <summary>
		/// Alternate getter by bid number.
		/// </summary>
		public static readonly string ALTKEY_BidNumber = "BidNumber";
		#endregion
		#region Properties
		public IAuctionSource AuctionSource {get; set;} 
		/// <summary>
		/// User's first and last name
		/// </summary>
		public Name Name {get; set;} 
		
		/// <summary>
		/// UserName is the bidnumber of the user
		/// </summary>
		public string UserName {get; set;} 
		
		/// <summary>
		/// All bids made by this user.
		/// </summary>
		public List<Bid> UserBids 
		{
			get
			{
				if(_userBids == null && Id.HasValue)
				{
					_userBids = AuctionSource.GetRelatedById<Bid,User>(Id.Value);
				}
				return _userBids;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Create an instance of user
		/// </summary>
		public User()
		{			
		}
		#endregion
	}
}
