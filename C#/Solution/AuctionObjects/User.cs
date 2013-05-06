/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/15/2012
 * Time: 3:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Interfaces.Sources;
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
		private List<Bid> _userBids = null;
		
		public IAuctionSource AuctionSource {get; set;} 
		
		public Name Name {get; set;} 
		
		public string UserName {get; set;} 
		
		[NonSerialized]
		public List<Bid> UserBids 
		{
			get
			{
				if(_userBids == null)
				{
					_userBids = AuctionSource.GetRelatedById<Bid,User>(Id);
				}
				return _userBids;
			}
		}
		
		#region Constructors
		public User()
		{
			
			
		}
		#endregion
	}
}
