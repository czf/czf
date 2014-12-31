/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 8/4/2013
 * Time: 6:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Czf.Domain.Global
{
	public enum SiteId
	{
		/// <summary>
		/// No site type specified
		/// </summary>
		None,
		/// <summary>
		/// Default website
		/// </summary>
		Default,
		/// <summary>
		/// For webAuction website
		/// </summary>
		WebAuction
	}
	
	/// <summary>
	/// Various status that auction items may be in.
	/// </summary>
	[Flags]
	public enum AuctionItemStatus
	{
		/// <summary>
		/// All items have this status
		/// </summary>
		Default = 1 << 0,
		/// <summary>
		/// Represents an item that is available for purchase/biddings.
		/// </summary>
		Active = 1 << 1,
		/// <summary>
		/// Represents an item that is not available for purchase/biddings.
		/// </summary>
		Inactive = 1 << 2,
		/// <summary>
		/// Represents an item that has been completed in purchases/biddings
		/// </summary>
		Closed = 1 << 3
		
	}
}
