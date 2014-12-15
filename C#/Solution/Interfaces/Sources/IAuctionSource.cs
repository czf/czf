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
namespace Czf.Domain.Interfaces.Sources
{
	/// <summary>
	/// Description of IAuctionSource.
	/// </summary>
	public interface IAuctionSource
	{
		/// <summary>
		/// Get a object of type T by integer identifier
		/// </summary>
		/// <param name="id">identifier</param>
		/// <returns></returns>
		T Get<T>(int id)
			where T : class;
		
		T GetByAlternateKey<T>(string KeyName, object KeyObject)
			where T : class;
		
		List<T> GetAll<T>()
			where T : class;
		
		List<ChildT> GetRelatedById<ChildT,ParentT>(int id)
			where ChildT : class
			where ParentT : class;
		
		List<ChildT> GetRelatedByAlternateLookupId<ChildT,ParentT>(string lookupName, int id)
			where ChildT : class
			where ParentT : class;
		
		bool Save<T>(T target)
			where T : class;
		
		T Create<T>()
			where T : class;
	}
}
