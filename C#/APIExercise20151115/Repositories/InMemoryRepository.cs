using System;
using System.Collections.Generic;
using System.Linq;
using Czf.Domain;
using Czf.Domain.InputModel;
using Czf.Domain.Interfaces;
namespace Czf.Repositories
{
	/// <summary>
	/// A simple repository for Mocking/testing data
	/// </summary>
	public class InMemoryRepository : IRepository
	{
		#region Privates
		private long InventoryItemId = 0;
		private long NotificationId = 0;
		
		
		private Dictionary<Tuple<Type, string>, Func<object, object>> lookups;
		private Dictionary<Tuple<Type, string>, Func<object, List<object>>> searches;
		private Dictionary<Tuple<Type, string>, Func<object>> parameterlessLookups;

		#endregion

		#region Properties
		/// <summary>
		/// Stores dates notifications for expired InventoryItems where checked.
		/// </summary>
		public List<ExpiredInventoryItemNotificationDate> ExpiredInventoryItemNotificationDates = new List<ExpiredInventoryItemNotificationDate>();
		
		/// <summary>
		/// Stores InventoryItems
		/// </summary>
		public List<InventoryItem> Items = new List<InventoryItem>();

		/// <summary>
		/// Stores Notifications
		/// </summary>
		public List<Notification> Notifications = new List<Notification>();
		#endregion

		#region Constructors
		/// <summary>
		/// Create an InMemoryRepository
		/// </summary>
		public InMemoryRepository()
		{
			lookups = new Dictionary<Tuple<Type, string>, Func<object, object>>()
			{
				{ Tuple.Create<Type,string>(typeof(InventoryItem), InventoryItem.LOOKUPMETHOD_label), GetInventoryItemByLabel }
			};
			parameterlessLookups = new Dictionary<Tuple<Type, string>, Func< object>>()
			{
				{ Tuple.Create<Type,string>(typeof(ExpiredInventoryItemNotificationDate), ExpiredInventoryItemNotificationDate.LOOKUPKEY_last), GetLastExpiredInventoryItemNotificationDate}
			};
			searches = new Dictionary<Tuple<Type, string>, Func<object, List<object>>>()
			{
				{ Tuple.Create<Type,string>(typeof(InventoryItem), InventoryItem.SEARCHMETHOD_ExpiredSince), SearchExpiredSinceDate }
			};
		}

		#endregion
		#region Methods
		#region Public
		/// <summary>
		/// Reset data stores for clean testing
		/// </summary>
		public void Reset()
		{
			ExpiredInventoryItemNotificationDates.Clear();
			Items.Clear();
			Notifications.Clear();
		}
		/// <summary>
		/// Add to an element to the data store
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <returns></returns>
		public T Add<T>(object input)
			where T : class
		{		
			if(input == null )
			{ throw new ArgumentNullException("input", "input can't be null"); }
			T result = null;

			if (typeof(T) == typeof(InventoryItem) && input is InventoryItemInputModel)
			{
				result =(T) AddInventoryItem((InventoryItemInputModel)input);
			}

			if(typeof(T) == typeof(Notification) && input is String)
			{
				result = (T) AddNotification((string)input);
			}
			
			if(typeof(T) == typeof(ExpiredInventoryItemNotificationDate) && input is ExpiredInventoryItemNotificationDate)
			{
				result = (T)AddExpiredInventoryItemNotificationDate((ExpiredInventoryItemNotificationDate)input);
            }

			if(result == null)
			{
				throw new InvalidOperationException("Unable to add input");
			}
			return result;
		}
		/// <summary>
		/// Remove an element from the data store
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
		public void Delete<T>(long id) where T : class
		{
			object target = null;
			if (typeof(T) == typeof(InventoryItem))
			{
				target = Items.FirstOrDefault(x => x.Id == id);
				if (target != null)
				{
					Items.Remove((InventoryItem)target);
				}
			}
		}

		/// <summary>
		/// Retrieve an element from the data store
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		public T Get<T>(long id) where T : class
		{
			object result = null;
			if (typeof(T) == typeof(InventoryItem))
			{
				InventoryItem item = Items.FirstOrDefault(x => x.Id == id);
				if(item != null)
				{
					//create a new element so we don't directly change this one.
					item = new InventoryItem(item.Id, item.Label, item.ExpirationDate);
					result = item;
				}
			}
			return (T)result;
		}

		/// <summary>
		/// Retrieve an element
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="lookupMethod"></param>
		/// <returns></returns>
		public T Get<T>(string lookupMethod) where T : class
		{
			if(lookupMethod == null)
			{ throw new ArgumentNullException("lookupMethod null");}
			Tuple<Type, string> key = GetProcessKey<T>(lookupMethod, parameterlessLookups.Keys.AsEnumerable());
			return (T)parameterlessLookups[key]();
		}

		/// <summary>
		/// Retrieve an element
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="lookupMethod"></param>
		/// <param name="lookupKey"></param>
		/// <returns></returns>
		public T Get<T>(string lookupMethod, object lookupKey) where T : class
		{
			if (lookupMethod == null || lookupKey == null)
			{
				throw new ArgumentNullException("lookupMethod and/or lookupKey null");
			}

			Tuple<Type, string> key = GetProcessKey<T>(lookupMethod, lookups.Keys.AsEnumerable());

			return (T)lookups[key](lookupKey);
        }

		/// <summary>
		/// Find all elements matching the search key for the search method
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="searchMethod"></param>
		/// <param name="searchKey"></param>
		/// <returns></returns>
		public List<T> Search<T>(string searchMethod, object searchKey) where T : class
		{
			if (searchMethod == null || searchKey == null)
			{
				throw new ArgumentNullException("searchMethod and/or searchKey null");
			}
			Tuple<Type, string> key = GetProcessKey<T>(searchMethod, searches.Keys.AsEnumerable());

			return searches[key](searchKey).Select(x=>(T)x).ToList();
		}
		#endregion
		#region Private
		private object GetLastExpiredInventoryItemNotificationDate()
		{
			ExpiredInventoryItemNotificationDate result = ExpiredInventoryItemNotificationDates.OrderByDescending(x => x.Date).LastOrDefault();
			if(result != null)
			{
				result = new ExpiredInventoryItemNotificationDate() { Date = result.Date };
			}
			return result;
		}

		private object GetInventoryItemByLabel(object labelObj)
		{
			string label = labelObj as string;
			if(label == null)
			{
				throw new ArgumentNullException("label is not valid");
			}

			InventoryItem result = Items.FirstOrDefault(x => x.Label == label);
			if(result != null)
			{
				//create a new element so we don't directly change this one.
				result = new InventoryItem(result.Id, result.Label, result.ExpirationDate);
			}
			return result;
		}

		private object AddInventoryItem(InventoryItemInputModel model)
		{
			InventoryItem result = new InventoryItem(++InventoryItemId, model.Label, model.ExpirationDate.Value);
			Items.Add(result);
			return new InventoryItem(result.Id, result.Label, result.ExpirationDate);
		}

		private object AddNotification(string message)
		{
			Notification result = new Notification(++NotificationId, message);
            Notifications.Add(result);
			return new Notification(result.Id, result.Message);
		}

		private Tuple<Type,string> GetProcessKey<T>(string lookupMethod, IEnumerable<Tuple<Type,string>> keys ) where T : class
		{
			Tuple<Type, string> key = Tuple.Create<Type, string>(typeof(T), lookupMethod);
			if (!keys.Contains(key))
			{
				throw new NotSupportedException("No process named: " + lookupMethod + " implemented for type: " + typeof(T).ToString() + ".");
			}
			return key;
		}

		private object AddExpiredInventoryItemNotificationDate(object input)
		{
			ExpiredInventoryItemNotificationDate result = (ExpiredInventoryItemNotificationDate)input;
			ExpiredInventoryItemNotificationDates.Add(result);
			return new ExpiredInventoryItemNotificationDate() { Date = result.Date };
        }

		private List<object> SearchExpiredSinceDate(object input)
		{
			return Items.Where(x => x.ExpirationDate >= (DateTime)input && x.ExpirationDate <= DateTime.Now).Select(x => (object)new InventoryItem(x.Id, x.Label, x.ExpirationDate)).ToList();
		}

		#endregion
		#endregion


	}
}
