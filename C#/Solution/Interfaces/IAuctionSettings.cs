/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/27/2014
 * Time: 4:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Czf.Domain.Interfaces
{
	/// <summary>
	/// Description of IAuctionSettings.
	/// </summary>
	public interface IAuctionSettings
	{
		/// <summary>
		/// Whether all connections to the application should be secured
		/// </summary>
		bool EnforceSecureConnection {get;}
		
	}
}
