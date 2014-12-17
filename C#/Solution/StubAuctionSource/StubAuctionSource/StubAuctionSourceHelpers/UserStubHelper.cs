/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/14/2014
 * Time: 6:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects;
using System.Linq;
using System.Collections.Generic;
using Czf.Domain.GenericObjects;
using Czf.Domain.BaseClasses;
namespace Czf.Sources.AuctionSource
{
	/// <summary>
	/// Description of UserStubHelper.
	/// </summary>
	public class UserStubHelper
	{
		#region Privates
		private readonly StubAuctionSource AuctionSource;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of UserStubHelper.
		/// </summary>
		public UserStubHelper(StubAuctionSource source)
		{
			AuctionSource = source;
			AuctionSource._domainDictionay.Add(typeof(User),new Dictionary<int,object>());
			
			AuctionSource._domainDictionay[typeof(User)].Add(1,
			                                   new User{
			                                   	Id = 1,
			                                   	AuctionSource = AuctionSource,
			                                   	Name = new Name("test", "user"),
			                                   	UserName = "123"
			                                   });
			AuctionSource._domainDictionay[typeof(User)].Add(1,
			                                   new User{
			                                   	Id = 2,
			                                   	AuctionSource = AuctionSource,
			                                   	Name = new Name("example", "tester"),
			                                   	UserName = "321"
			                                   });
			AuctionSource._relatedGetters.Add(
				new Tuple<Type,Type>(typeof(Bid),typeof(User)), 
				(int userId) =>  AuctionSource.GetAll<Bid>().Where(bid=>bid.UserId == userId).ToList<object>()
			);
			AuctionSource._alternateKeyGetters.Add(
				new Tuple<Type, string>(typeof(User),User.ALTKEY_BidNumber),
				(object keyObject) => 
				{
					string keyValue = keyObject as string;
					return AuctionSource.GetAll<User>().Where(user => user.UserName == keyValue).ToList();
				}
			);
		}
		#endregion
		#region Methods
		#endregion
	}
}
