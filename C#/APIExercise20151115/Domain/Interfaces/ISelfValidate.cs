using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czf.Domain.Interfaces
{
	public interface ISelfValidate
	{
		/// <summary>
		/// Determine if the state of this object is valid
		/// </summary>
		/// <returns>empty if no errors, otherwise all errors</returns>
		NameValueCollection CheckValidity();
	}
}
