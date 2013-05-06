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

namespace Czf.Domain.BaseClasses
{
	/// <summary>
	/// Description of AuctionItem.
	/// </summary>
	public class BaseAuctionItem : IdentifiedByInt, IAuctionSourceConsumer
	{
		
		
		#region properties
		/// <summary>
		/// Gets or sets the Title or the item.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		public string Title {get; set;} 
		
		/// <summary>
		/// Gets or sets the description of the item.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description {get; set;} 
		
		/// <summary>
		/// Gets or sets the auction source data.
		/// </summary>
		/// <value>
		/// The auction source.
		/// </value>
		public IAuctionSource AuctionSource {get; set;} 
		
		/// <summary>
		/// Gets or sets calculated value of the AuctionItem
		/// </summary>
		/// <value>
		/// The true value.
		/// </value>
		public double Value {get; set;}
		
		#endregion
		
		#region constructors
		public BaseAuctionItem()
		{
		}
		#endregion
		
		#region methods
		#endregion
		
		
	}
}
