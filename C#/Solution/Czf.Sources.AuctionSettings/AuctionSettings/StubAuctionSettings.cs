/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/27/2014
 * Time: 4:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using Czf.Domain.Interfaces;
namespace Czf.Sources.AuctionSettings
{
	/// <summary>
	/// Contains the hardcoded settings values for Auction application.
	/// </summary>
	public class StubAuctionSettings : IAuctionSettings
	{
		/// <summary>
		/// Whether all connections to the application should be secured
		/// </summary>
		public bool EnforceSecureConnection 
		{	get {return false;}	}
		
	}
}