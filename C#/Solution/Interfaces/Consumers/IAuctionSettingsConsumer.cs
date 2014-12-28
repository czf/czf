/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/27/2014
 * Time: 4:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.Interfaces;
namespace Czf.Domain.Interfaces.Consumers
{
	/// <summary>
	/// Description of IAuctionSettingsConsumer.
	/// </summary>
	public interface IAuctionSettingsConsumer
	{
		/// <summary>
		/// A reference to AuctionSettings implementation
		/// </summary>
		IAuctionSettings AuctionSettings{get; set;}
		
	}
}
