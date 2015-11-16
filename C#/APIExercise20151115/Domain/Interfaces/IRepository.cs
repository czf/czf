using System.Collections.Generic;

namespace Czf.Domain.Interfaces
{
	/// <summary>
	/// Represents a Repository
	/// </summary>
	public interface IRepository
	{

		/// <summary>
		/// Returns item with identifiier ID
		/// </summary>
		/// <typeparam name="T">Type returning</typeparam>
		/// <param name="id">unique identifier</param>
		/// <returns>element with id or null if no such element</returns>
		T Get<T>(long id) where T : class;

		/// <summary>
		/// Returns item using specified lookup method and lookup key
		/// </summary>
		/// <typeparam name="T">returning type</typeparam>
		/// <param name="lookupMethod">unique lookup method ie ByLabel</param>
		/// <returns>element with lookupMethod</returns>
		T Get<T>(string lookupMethod) where T : class;

		/// <summary>
		/// Returns all items using specified search method and search key
		/// </summary>
		/// <param name="searchMethod"></param>
		/// <param name="searchKey">value to search with</param>
		/// <returns>elements that match the searchkey using the search method</returns>
		List<T> Search<T>(string searchMethod, object searchKey) where T : class;

		/// <summary>
		/// Returns item using specified lookup method and lookup key
		/// </summary>
		/// <typeparam name="T">returning type</typeparam>
		/// <param name="lookupMethod">unique lookup method ie ByLabel</param>
		/// <param name="lookupKey">value to lookup with</param>
		/// <returns>element with lookupkey using lookupMethod</returns>
		T Get<T>(string lookupMethod, object lookupKey) where T : class;

		/// <summary>
		/// Remove an item from the repository. When id doesn't exist nothing happens.
		/// </summary>
		/// <typeparam name="T">Type to delete</typeparam>
		/// <param name="id">id to delete</param>
		void Delete<T>(long id) where T : class;

		/// <summary>
		/// Add an element to the repository
		/// </summary>
		/// <typeparam name="T">type to add</typeparam>
		/// <param name="input">inputmodel to create the element from</param>
		/// <returns>the new element that was added</returns>
		T Add<T>(object input) where T : class;
	}
}
