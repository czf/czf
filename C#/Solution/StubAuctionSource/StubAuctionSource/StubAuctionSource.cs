/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 5/21/2013
 * Time: 8:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain;
using Czf.Domain.AuctionObjects;
using Czf.Domain.BaseClasses;
using Czf.Domain.GenericObjects;
using Czf.Domain.Interfaces.Sources;
using System.Collections.Generic;

namespace Czf.Sources.AuctionSource
{
	/// <summary>
	/// A temporary data source for auction data.
	/// </summary>
	/// <remarks>avoiding database stuff so I can work on domain/controller/view stuff</remarks>
	public class StubAuctionSource : IAuctionSource
	{
		#region Private
		private List<object> _helpers;
		#region something
		internal Dictionary<Type,Dictionary<int,object>> _domainDictionay {get; set;} 
		#endregion
		#endregion
		
		public StubAuctionSource()
		{
			_domainDictionay = new Dictionary<Type, Dictionary<int, object>>();
			_helpers = new List<object>()
			{
				new BidStubHelper(this),
				new BidItemStubHelper(this),
				new UserStubHelper(this)
			};
			
			
			
			
			
		}
		
		public T Get<T>(int id) where T : class
		{
			T result = null;
			if (_domainDictionay.ContainsKey(typeof(T))) {
				if(_domainDictionay[typeof(T)].ContainsKey(id))
				{
					result = (T)_domainDictionay[typeof(T)][id];
				}
			}
			return result;
		}
		
		public List<T> GetAll<T>() where T : class
		{
			throw new NotImplementedException();
		}
		
		public T GetByAlternateKey<T>(string KeyName, object KeyObject) where T : class
		{
			throw new NotImplementedException();
			//TODO Implement a getter for each Tuple<T,string>(typeof(T), KeyName) that casts keyobject to the key value and compares to a property on T
		}
		
		public List<ChildT> GetRelatedById<ChildT, ParentT>(int id) where ChildT : class where ParentT : class
		{
			throw new NotImplementedException();
		}
		
		public List<ChildT> GetRelatedByAlternateLookupId<ChildT,ParentT>(string lookupName, int id)
			where ChildT : class
			where ParentT : class
		{
			throw new NotImplementedException();
		}
		
		public List<ChildT> GetRelatedByAlternateLookupId<ChildT, ParentT>(int id) where ChildT : class where ParentT : class
		{
			throw new NotImplementedException();
		}
		
		public bool Save<T>(T target) where T : class
		{
			throw new NotImplementedException();
		}
		
		public T Create<T>() where T : class
		{
			throw new NotImplementedException();
		}
	}
}
