/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/27/2012
 * Time: 10:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
namespace Czf.Interfaces.Sources
{
	/// <summary>
	/// Description of IAuctionSource.
	/// </summary>
	public interface IAuctionSource
	{
		T Get<T>(int id)
			where T : class;
		
		List<ChildT> GetRelatedById<ChildT,ParentT>(int id)
			where ChildT : class
			where ParentT : class;
	}
}
