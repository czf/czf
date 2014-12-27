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
using Czf.Domain.Interfaces.Consumers;
using System.Collections.Generic;
using System.Linq;
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
		internal Dictionary<Type,Dictionary<int,object>> _domainDictionay;
		internal Dictionary<Tuple<Type, Type>, Func<int, List<object>>> _relatedGetters;
		internal Dictionary<Tuple<Type,string>, Func<object,object>> _alternateKeyGetters;
		internal Dictionary<Type, Func<object, bool>> _savers;
		internal Dictionary<Type, Func<object, bool>> _deleters;
		internal Dictionary<Type, Func<int, object>> _customGetter;
		#endregion
		#endregion
		/// <summary>
		/// Create an instance of StubAuctionSource
		/// </summary>
		public StubAuctionSource()
		{
			_domainDictionay = new Dictionary<Type, Dictionary<int, object>>();
			_relatedGetters = new Dictionary<Tuple<Type, Type>, Func< int, List<object>>>();
			_alternateKeyGetters = new Dictionary<Tuple<Type,string>, Func<object, object>>();
			_savers = new Dictionary<Type, Func<object, bool>>();
			_deleters = new Dictionary<Type, Func<object, bool>>();
			_customGetter = new Dictionary<Type, Func<int, object>>();
			_helpers = new List<object>()
			{
				new BidStubHelper(this),
				new BidItemStubHelper(this),
				new UserStubHelper(this),
				new BaseAuctionItemStubHelper(this)
			};
			
		}
		/// <summary>
		/// Get an object of type T by integer identifier
		/// </summary>
		/// <param name="id">identifier</param>
		/// <returns></returns>
		public T Get<T>(int id) where T : class
		{
			Type key = typeof(T);
			T result = null;
			if (_domainDictionay.ContainsKey(key)) {
				if(_domainDictionay[key].ContainsKey(id))
				{
					result = (T)_domainDictionay[key][id]; // passing a reference so modifiations are made directly 
																 // might need copy constructors for actual tests later
				}
			}
			else if(_customGetter.ContainsKey(key))
			{
				result = (T)_customGetter[key](id);
			}
			else
			{
				throw new NotImplementedException("type " + key + " is missing from domainDictionary");
			}
			return result;
		}
		
		/// <summary>
		/// Get a copy of all objects of type T
		/// </summary>
		/// <returns></returns>
		public List<T> GetAll<T>() where T : class
		{
			List<T> result = new List<T>();
			if (_domainDictionay.ContainsKey(typeof(T))) {
				return _domainDictionay[typeof(T)].Select(x=> (T) x.Value).ToList();
			}
			throw new NotImplementedException("type " + typeof(T) + " is missing from domainDictionary");			
		}
		/// <summary>
		/// Get an object of type T by alternate key KeyObject named by KeyName
		/// </summary>
		/// <param name="KeyName"></param>
		/// <param name="KeyObject"></param>
		/// <returns></returns>
		public T GetByAlternateKey<T>(string KeyName, object KeyObject) where T : class
		{
			Tuple<Type,string> key = new Tuple<Type, string>(typeof(T),KeyName);
			T result = null;
			if(_alternateKeyGetters.ContainsKey(key))
			{
				result = (T)_alternateKeyGetters[key](KeyObject);
			}
			
			return result;
		}
		/// <summary>
		/// Get objects of type ChildT related to object of type ParentT with int identifier id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<ChildT> GetRelatedById<ChildT, ParentT>(int id) where ChildT : class where ParentT : class
		{
			Tuple<Type,Type> relatedKey = new Tuple<Type,Type>(typeof(ChildT), typeof(ParentT));
			
			if(_domainDictionay.ContainsKey(typeof(ChildT)) && _relatedGetters.ContainsKey(relatedKey))
			{
				return _relatedGetters[relatedKey](id).Select(x=> (ChildT)x).ToList();
			}
			throw new NotImplementedException();
		}
		/// <summary>
		/// Get objects of type ChildT related to object of type ParentT using keyName alternate keyObject
		/// </summary>
		/// <param name="keyName"></param>
		/// <param name="keyObject"></param>
		/// <returns></returns>
		public List<ChildT> GetRelatedByAlternateKey<ChildT,ParentT>(string keyName, object keyObject)
			where ChildT : class
			where ParentT : class
		{
			throw new NotImplementedException();
		}
		
//		public List<ChildT> GetRelatedByAlternateLookupId<ChildT, ParentT>(int id) where ChildT : class where ParentT : class
//		{
//			throw new NotImplementedException();
//		}
		
		/// <summary>
		/// Save the target object of type T
		/// </summary>
		/// <param name="targetObj"></param>
		/// <returns></returns>
		public bool Save<T>(T targetObj) where T :  IdentifiedByInt
		{
			IdentifiedByInt target = targetObj as IdentifiedByInt;
			Dictionary<int, object> all = _domainDictionay[typeof(T)];
			if(!target.Id.HasValue) //TODO update this to maintain identity after delete
			{
				if(all.Any())
					target.Id = all.Keys.Max();
				else
					target.Id = 1;
			}
			all[target.Id.Value] = target;
			return true;
		}
		
		/// <summary>
		/// Create an object of type T
		/// </summary>
		/// <returns></returns>
		public T Create<T>() where T : class , new()
		{
			T result = new T();
			IAuctionSourceConsumer consumer = result as IAuctionSourceConsumer;
			if(consumer != null)
			{
				consumer.AuctionSource = this;
			}
			return result;
		}
	}
}
