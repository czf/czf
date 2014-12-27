using System;
using System.Diagnostics.Eventing.Reader;
using Czf.Domain.BaseClasses;
using Czf.Domain.AuctionObjects;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.Interfaces.Consumers;
namespace Czf.Domain.AuctionObjects
{
	/// <summary>
	/// Bids are placed on BidItem instances by a User.
	/// </summary>
	public class Bid : IdentifiedByInt, IAuctionSourceConsumer
	{
		
		#region Private
		
		private User _bidUser = null;
		
		#endregion
		
		#region Properties
		/// <summary>
		/// Get or Set the value of the bid
		/// </summary>
		public decimal Amount {get; set;} 
		
		/// <summary>
		/// When the bid was processed
		/// </summary>
		public DateTime DateMade {get; set;} 
		
		/// <summary>
		/// Get or Set the AuctionSouce
		/// </summary>
		public IAuctionSource AuctionSource {get; set;} 
		
		/// <summary>
		/// Id of the User that submitted the bid
		/// </summary>
		public int UserId {get; set;} 
		
		/// <summary>
		/// Get or set if the Bid has been cancelled
		/// </summary>
		public bool Canceled {get; set;} 
		
		/// <summary>
		/// The item Id this bid is for
		/// </summary>
		public int ItemIdForBid {get; set;}
		
		/// <summary>
		/// Gets the appropriate AuctionItem using ItemIdForBid.
		/// <returns>An Item decending from BaseAuctionItem</returns>
		/// </summary>
		public BaseAuctionItem Item 
		{
			get
			{
				if( AuctionSource.Get<BidItem>(ItemIdForBid) == null)
				{
					return AuctionSource.Get<PurchaseItem>(ItemIdForBid);
				}
				return AuctionSource.Get<BidItem>(ItemIdForBid) ;
			}
		}
		
		/// <summary>
		/// Get or set the user owning the bid
		/// </summary>
		public User BidUser
		{
			get
			{
				if(_bidUser == null)
				{
					_bidUser = AuctionSource.Get<User>(UserId);
				}
				return _bidUser;
			}
			set
			{
				_bidUser = value;
				UserId = _bidUser.Id.Value;
			}		
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// Create an instance of bid
		/// </summary>
		public Bid()
		{
			Amount = 0;
			DateMade = DateTime.Now;
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves this instance to the auction source.
		/// </summary>
		/// <returns>True if successfully saved.</returns>
		public bool Save()
		{
			return AuctionSource.Save<Bid>(this);
		}
		#endregion
	}
}
