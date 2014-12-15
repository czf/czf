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

namespace Czf.Sources.StubAuctionSource
{
	/// <summary>
	/// A temporary data source for auction data.
	/// </summary>
	/// <remarks>avoiding database stuff so I can work on domain/controller/view stuff</remarks>
	public class StubAuctionSource : IAuctionSource
	{
		#region Private
		#region something
		private Dictionary<Type,Dictionary<int,object>> _domainDictionay {get; set;} 
		#endregion
		#endregion
		
		public StubAuctionSource()
		{
			_domainDictionay = new Dictionary<Type, Dictionary<int, object>>();
			_domainDictionay.Add(typeof(Bid),new Dictionary<int,object>());
			_domainDictionay.Add(typeof(BidItem),new Dictionary<int,object>());
			_domainDictionay.Add(typeof(User),new Dictionary<int,object>());
			
			_domainDictionay[typeof(BidItem)].Add(1,
			                                      	new BidItem{
			                                      	Id = 1,
			                                      	AuctionSource = this,	
			                                      	Description = "A widget that widgets.",
			                                      	Title = "widget 1",
			                                      	Value = 100			                                      			       
			                                      });
			_domainDictionay[typeof(BidItem)].Add(2,
			                                      	new BidItem{
			                                      	Id = 2,
			                                      	AuctionSource = this,	
			                                      	Description = "A do something that somethings.",
			                                      	Title = "do something 1",
			                                      	Value = 101
			                                      });
			_domainDictionay[typeof(User)].Add(1,
			                                   new User{
			                                   	Id = 1,
			                                   	AuctionSource = this,
			                                   	Name = new Name("test", "user"),
			                                   	UserName = "123"
			                                   });
			_domainDictionay[typeof(User)].Add(1,
			                                   new User{
			                                   	Id = 2,
			                                   	AuctionSource = this,
			                                   	Name = new Name("example", "tester"),
			                                   	UserName = "321"
			                                   });
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
