using System;
using System.Diagnostics.Eventing.Reader;
using Czf.Domain.BaseClasses;
using Czf.Domain.AuctionObjects;
using Czf.Interfaces.Sources;
namespace Czf.Domain.AuctionObjects
{
	/// <summary>
	/// Description of Bid.
	/// </summary>
	public class Bid : IdentifiedByInt
	{
	
		private User _bidUser = null;
		
		public decimal Amount {get; set;} 
		
		public DateTime DateMade {get; set;} 
		
		public IAuctionSource AuctionSource {get; set;} 
		
		public int UserId {get; set;} 
		
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
		
		public Bid()
		{
			Amount = 0;
			DateMade = DateTime.Now;
		}
	}
}
