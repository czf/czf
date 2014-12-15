using System;
using System.Diagnostics.Eventing.Reader;
using Czf.Domain.BaseClasses;
using Czf.Domain.AuctionObjects;
using Czf.Domain.Interfaces.Sources;
namespace Czf.Domain.AuctionObjects
{
	/// <summary>
	/// Bids are placed on BidItem instances by a User.
	/// </summary>
	public class Bid : IdentifiedByInt
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
		
		public int UserId {get; set;} 
		
		/// <summary>
		/// Get or set if the Bid has been cancelled
		/// </summary>
		public bool Canceled {get; set;} 
		
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
