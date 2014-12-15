/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 5/27/2013
 * Time: 4:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.Interfaces.Consumers;

namespace Czf.Domain.AuctionObjects.AuctionSessionObjects
{
	/// <summary>
	/// Description of AuctionSession.
	/// </summary>
	public class AuctionSession : IAuctionSourceConsumer
	{
		#region Properties
		/// <summary>
		/// Instance of the AuctionSource
		/// </summary>
		public IAuctionSource AuctionSource {get; set;} 
		
		/// <summary>
		/// User of the current session
		/// </summary>
		public User User {get; set;} 
		
		#endregion
		#region Constructors
		/// <summary>
		/// Create an instance of AuctionSession
		/// </summary>
		public AuctionSession()
		{
		
		}
		#endregion
	}
}
