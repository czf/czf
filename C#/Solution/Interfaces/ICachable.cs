/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/24/2012
 * Time: 12:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Czf.Domain.Interfaces
{
	/// <summary>
	/// Description of ICachable.
	/// </summary>
	public interface ICachable
	{
		bool ReadyForCache();
	}
}
