/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 5/5/2013
 * Time: 7:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Czf.Util.Common
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public static class StringExtensions
	{
		#region methods
		
		public static string NullToEmpty(this string input)
		{
			return input == null ? string.Empty : input;
		}
		
		#endregion
	
	}
}
