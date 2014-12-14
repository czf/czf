/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/28/2012
 * Time: 9:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.Interfaces.Sources;

namespace Czf.Domain.Interfaces.Consumers
{
	/// <summary>
	/// Has a property of IAuctionSource
	/// </summary>
	public interface IAuctionSourceConsumer
	{
		/// <summary>
		/// The AuctionSource reference.
		/// </summary>
		IAuctionSource AuctionSource {get; set;} 
	}
}
