/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/26/2014
 * Time: 6:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects;
using System.Linq;
using System.Collections.Generic;
using Czf.Domain.BaseClasses;
namespace Czf.Sources.AuctionSource
{
	/// <summary>
	/// Description of BaseAuctionItemStubHelper.
	/// </summary>
	public class BaseAuctionItemStubHelper
	{
		#region Privates
		private readonly StubAuctionSource AuctionSource;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of BaseAuctionItemStubHelper.
		/// </summary>
		public BaseAuctionItemStubHelper(StubAuctionSource source)
		{
			AuctionSource = source;
			AuctionSource._customGetter.Add(typeof(BaseAuctionItem),GetBaseAuctionItemById);
		}
		#endregion
		#region Methods
		private BaseAuctionItem GetBaseAuctionItemById(int id)
		{
			BaseAuctionItem result = AuctionSource._domainDictionay.
				//only for types that are BaseAuctionItem
				Where(x=> x.Key.IsSubclassOf(typeof(BaseAuctionItem))).
				SelectMany(x=>x.Value). // get the object dictionarys
				Select(x=>(BaseAuctionItem)x.Value). //get the objects as basauctionitem
				FirstOrDefault(x=>x.Id ==id); //get the specific one or null
			
			return result;
		}
		#endregion
	}
}
