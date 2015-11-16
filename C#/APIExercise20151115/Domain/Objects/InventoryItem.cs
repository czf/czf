using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Czf.Domain.Interfaces;
namespace Czf.Domain
{
	/// <summary>
	/// Representation of an item in the inventory
	/// </summary>
    public class InventoryItem 
    {
		/// <summary>
		/// Lookup key for finding InventoryItem by Label
		/// </summary>
		public static readonly string LOOKUPMETHOD_label = "GetByLabel";

		/// <summary>
		/// Search key for finding expired Inventory Items since a defined date.
		/// </summary>
		public static readonly string SEARCHMETHOD_ExpiredSince = "GetExpiredSince";

		/// <summary>
		/// Unique Identifier of the InventoryItem
		/// </summary>
		public virtual long Id { get; protected set; }

		/// <summary>
		/// Label content of the item
		/// </summary>
		public virtual string Label { get; protected set; }

		/// <summary>
		/// Date the item expires
		/// </summary>
		public virtual DateTime ExpirationDate { get; protected set; }

		/// <summary>
		/// Create a new InventoryItem
		/// </summary>
		/// <param name="label">content of label</param>
		/// <param name="expirationDate">Date the item expires</param>
		public InventoryItem(long id, string label, DateTime expirationDate)
		{
			Id = id;
			Label = label;
			ExpirationDate = expirationDate;
		}
	}
}
