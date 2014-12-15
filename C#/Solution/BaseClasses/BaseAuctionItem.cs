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
using Czf.Domain.Interfaces.Consumers;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.Global;
namespace Czf.Domain.BaseClasses
{
	/// <summary>
	/// Description of AuctionItem.
	/// </summary>
	public abstract class BaseAuctionItem : IdentifiedByInt, IAuctionSourceConsumer
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
		public decimal Value {get; set;}
		
		/// <summary>
		/// Gets or sets the Item status
		/// </summary>
		/// <returns></returns>
		public AuctionItemStatus Status {get; set;}
		#endregion
		
		#region constructors
		/// <summary>
		/// Create an instance ofBaseAuctionItem.  This is abstract class cannot be called directly
		/// </summary>
		public BaseAuctionItem()
		{
			Title = string.Empty;
			Description = string.Empty;
			Status = AuctionItemStatus.Inactive;
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Updates this Item to active
		/// </summary>
		/// <returns></returns>
		public bool Activate()
		{
			return ChangeStatus(AuctionItemStatus.Active);
		}
		
		/// <summary>
		/// Closes this Item from actions
		/// </summary>
		/// <returns></returns>
		public bool Close()
		{
			return ChangeStatus(AuctionItemStatus.Closed);
		}
		
		/// <summary>
		/// Saves the instance to the AuctionSource. 
		/// </summary>
		public abstract bool Save();
		private bool ChangeStatus(AuctionItemStatus status)
		{
			if(status == Status)
			{
				return true;
			}
			AuctionItemStatus oldStatus = Status;
			Status = status;
			bool result = this.Save();
			if(!result)
			{
				Status = oldStatus;
			}
			return result;
		}
		#endregion
		
		
	}
}
