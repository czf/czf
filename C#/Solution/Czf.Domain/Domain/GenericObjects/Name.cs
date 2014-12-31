/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/27/2012
 * Time: 10:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using Czf.Util.Common;

namespace Czf.Domain.GenericObjects
{
	/// <summary>
	/// Description of Name.
	/// </summary>
	public class Name
	{
		/// <summary>
		/// First name
		/// </summary>
		public string FirstName {get; set;} 
		
		/// <summary>
		/// Last name
		/// </summary>
		public string LastName {get; set;} 
		
		/// <summary>
		/// Creates a name object
		/// </summary>
		/// <param name="first"></param>
		/// <param name="last"></param>
		public Name(string first, string last)
		{
			
			FirstName = first;
			LastName = last;
		}
	}
}
