/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/28/2012
 * Time: 9:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Interfaces.Sources;

namespace Czf.Interfaces.Consumers
{
	/// <summary>
	/// Description of IAuctionConsumer.
	/// </summary>
	public interface IAuctionConsumer
	{
		IAuctionSource AuctionSource;
	}
}
