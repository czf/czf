using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czf.Domain
{
	/// <summary>
	/// Represents the the date notifications were processed for expired InventoryItems
	/// </summary>
	public class ExpiredInventoryItemNotificationDate
	{
		/// <summary>
		/// Lookup key for finding the last date notifications were processed 
		/// for Expired Items
		/// </summary>
		public static readonly string LOOKUPKEY_last = "GetLast";

		/// <summary>
		/// The date the noticiations were processed for expired InventoryItems.
		/// </summary>
		public DateTime Date { get; set; }
	}
}
