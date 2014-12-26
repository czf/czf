/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/25/2014
 * Time: 3:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects.AuctionSessionObjects;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.Interfaces.Consumers;
namespace Czf.App.WebAuction.Models
{
	/// <summary>
	/// Description of GlobalAuctionViewModel.
	/// </summary>
	public class GlobalAuctionViewModel : IAuctionSourceConsumer
	{
		#region Privates
		#endregion
		#region Properties
		/// <summary>
		/// THe auction data relveant to the auction 
		/// </summary>
		public AuctionSession AuctionSession {get; set;}
		
		/// <summary>
		/// A reference to the AuctionSource
		/// </summary>
		public IAuctionSource AuctionSource {get; set;}
		
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of GlobalAuctionViewModel.
		/// </summary>
		public GlobalAuctionViewModel()
		{}
		#endregion
		#region Methods
		#endregion
	}
}
