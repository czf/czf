/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/25/2014
 * Time: 2:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects;
using System.Collections.Generic;
using Czf.Domain.BaseClasses;
namespace Czf.App.WebAuction.Models
{
	/// <summary>
	/// Description of ItemListViewModel.
	/// </summary>
	public class ItemListViewModel : GlobalAuctionViewModel
	{
		#region Privates
		#endregion
		#region Properties
		/// <summary>
		/// Items to be listed
		/// </summary>
		public List<BaseAuctionItem> AuctionItems
		{
			get;
			protected set;
		}
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of ItemListViewModel.
		/// </summary>
		public ItemListViewModel()
		{
			AuctionItems = new List<BaseAuctionItem>();
		}
		#endregion
		#region Methods
		#endregion
	}
}
