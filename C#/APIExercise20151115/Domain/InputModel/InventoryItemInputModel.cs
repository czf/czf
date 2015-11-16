using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Czf.Domain;
using Czf.Domain.Interfaces;
using System.Collections.Specialized;

namespace Czf.Domain.InputModel
{
	public class InventoryItemInputModel : ISelfValidate
	{		
		/// <summary>
		/// Label of the item
		/// </summary>
		public string Label { get; set; }

		/// <summary>
		/// Date it expires
		/// </summary>
		public DateTime? ExpirationDate { get; set; }


		/// <summary>
		/// Determine if the state of this object is valid
		/// </summary>
		/// <returns>empty if no errors, otherwise all errors</returns>
		public NameValueCollection CheckValidity()
		{
			NameValueCollection result = new NameValueCollection();
			if(String.IsNullOrEmpty(Label.Trim()))
			{
				result.Add("Label", "required field");
			}

			if(ExpirationDate.HasValue && ExpirationDate.Value < DateTime.Now)
			{
				result.Add("ExpirationDate", "cannot add expired item to inventory");
			}
			else if(!ExpirationDate.HasValue)
			{
				result.Add("ExpirationDate", "required field");
			}
			return result;
		}

	}
}
