/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/25/2014
 * Time: 6:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects;
using Czf.Domain.BaseClasses;
using Czf.App.WebAuction.Models.InputViewModel;
namespace Czf.App.WebAuction.Models
{
	/// <summary>
	/// Description of ItemViewModel.
	/// </summary>
	public class ItemViewModel : GlobalAuctionViewModel
	{
		#region Privates
		#endregion
		#region Properties
		/// <summary>
		/// The Item for this view model
		/// </summary>
		public BaseAuctionItem Item {get; set;}
		
		/// <summary>
		/// Input data for this bid action
		/// </summary>
		public BidActionInputModel Input {get; set;}
		
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of ItemViewModel.
		/// </summary>
		public ItemViewModel()
		{
			Input = new BidActionInputModel();
		}
		#endregion
		#region Methods
		#endregion
	}
}
