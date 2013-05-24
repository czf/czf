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
	/// <remarks>avoiding database stuff so I can work on controller/view stuff</remarks>
	public class StubAuctionSource : IAuctionSource
	{
		#region Private
		#region something
		Dictionary<Type,Dictionary<int,IdentifiedByInt>> _domainDictionay {get; set;} 
		#endregion
		#endregion
		
		public StubAuctionSource()
		{
			_domainDictionay = new Dictionary<Type, Dictionary<int, IdentifiedByInt>>();
			_domainDictionay.Add(typeof(Bid),new Dictionary<int,IdentifiedByInt>());
			_domainDictionay.Add(typeof(BidItem),new Dictionary<int,IdentifiedByInt>());
			_domainDictionay.Add(typeof(User),new Dictionary<int,IdentifiedByInt>());
			
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
			                                   }
			_domainDictionay[typeof(User)].Add(1,
			                                   new User{
			                                   	Id = 2,
			                                   	AuctionSource = this,
			                                   	Name = new Name("example", "tester"),
			                                   	UserName = "321"
			                                   }                                   
												
		}
		
		public T Get<T>(int id)
		{
			T result = null;
			if (_domainDictionay.ContainsKey(typeof(T))) {
				if(_domainDictionay[typeof(T)].ContainsKey(id))
				{
					result = _domainDictionay[typeof(T)][id];
				}
			}
			return result;
		}
		
		public List<ChildT> GetRelatedById<ChildT, ParentT>(int id)
		{
			throw new NotImplementedException();
		}
		
		public System.Collections.Generic.List<ChildT> GetRelatedByAlternateLookupId<Child, Parent>(int id)
		{
			throw new NotImplementedException();
		}
		
		public bool Save<T>(T target)
		{
			throw new NotImplementedException();
		}
		
		public T Create<T>()
		{
			throw new NotImplementedException();
		}
	}
}
