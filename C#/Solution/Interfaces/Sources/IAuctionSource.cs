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
		/// Get an object of type T by integer identifier
		/// </summary>
		/// <param name="id">identifier</param>
		/// <returns></returns>
		T Get<T>(int id)
			where T : class;
		
		/// <summary>
		/// Get an object of type T by alternate key KeyObject named by KeyName
		/// </summary>
		/// <param name="KeyName"></param>
		/// <param name="KeyObject"></param>
		/// <returns></returns>
		T GetByAlternateKey<T>(string KeyName, object KeyObject)
			where T : class;
		
		/// <summary>
		/// Get all objects of type T
		/// </summary>
		/// <returns></returns>
		List<T> GetAll<T>()
			where T : class;
		
		/// <summary>
		/// Get objects of type ChildT related to object of type ParentT with int identifier id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		List<ChildT> GetRelatedById<ChildT,ParentT>(int id)
			where ChildT : class
			where ParentT : class;
		
		/// <summary>
		/// Get objects of type ChildT related to object of type ParentT using keyName alternate keyObject
		/// </summary>
		/// <param name="keyName"></param>
		/// <param name="keyObject"></param>
		/// <returns></returns>
		List<ChildT> GetRelatedByAlternateKey<ChildT,ParentT>(string keyName, object keyObject)
			where ChildT : class
			where ParentT : class;
		
		/// <summary>
		/// Save the target object of type T
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		bool Save<T>(T target)
			where T : class;
		
		/// <summary>
		/// Create an object of type T
		/// </summary>
		/// <returns></returns>
		T Create<T>()
			where T : class, new();
	}
}
