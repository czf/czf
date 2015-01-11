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
		
		/// <summary>
		/// if the string is null empty is returned
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string NullToEmpty(this string input)
		{
			return input ?? string.Empty;
		}
		
		/// <summary>
		/// Returns the first part of the strings, up until the character c. If c is not found in the
		/// string the whole string is returned.
		/// </summary>
		/// <param name="s">String to truncate</param>
		/// <param name="c">Character to stop at.</param>
		/// <returns>Truncated string</returns>
		/// <remarks>
		/// <para>http://extensionmethod.net/csharp/string/leftof</para>
		/// Author: Gaston Verelst
		/// </remarks>
		public static string LeftOf(this string s, char c)
		{
		    int ndx = s.IndexOf(c);
		    if (ndx >= 0)
		    {
		    return s.Substring(0, ndx);
		    }
		 
		    return s;
		}
		
		#endregion
	
	}
}
