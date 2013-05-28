/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 5/27/2013
 * Time: 4:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects.AuctionSessionObjects;
using Czf.Domain.Interfaces.Consumers;
namespace Czf.Domain.Interfaces
{
	/// <summary>
	/// Description of IHasAuctionSession.
	/// </summary>
	public interface IHasAuctionSession : IAuctionSourceConsumer
	{
		/// <summary>
		/// Gets or sets the auction session.
		/// </summary>
		AuctionSession AuctionSession {get; set;} 
	}
}
