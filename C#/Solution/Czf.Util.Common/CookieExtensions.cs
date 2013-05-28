/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 5/27/2013
 * Time: 5:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web;
namespace Czf.Util.Common
{
	public static class CookieExtensions
	{
		/// <summary>
		/// Fetches a value from a 
		/// </summary>
		/// <param name="cookie">The cookie.</param>
		/// <param name="httpContext">The HTTP context.</param>
		/// <param name="cookieKey">The cookie key.</param>
		/// <returns>String representing a DateTime (short date, short time).</returns>
		public static string FetchCookieValueAsString(this HttpCookie cookie, HttpContextBase httpContext, string cookieKey)
		{
			//if ((cookie != null) && ((cookie.Name == _cookieName) || (cookie.Name == _cookieNameSession)) && (httpContext != null))
			if (cookie != null && httpContext != null)
			{
				return HttpUtility.UrlDecode(cookie[cookieKey]);
			}
			return null;
		}
		
		/// <summary>
		/// Fetches a date from a date-based cookie key/value pair.
		/// </summary>
		/// <param name="cookie">The cookie.</param>
		/// <param name="httpContext">The HTTP context.</param>
		/// <param name="cookieKey">The cookie key.</param>
		/// <returns>String representing a DateTime (short date, short time).</returns>
		public static int? FetchCookieValueAsInt(this HttpCookie cookie, HttpContextBase httpContext, string cookieKey)
		{
			string cookieValueString = cookie.FetchCookieValueAsString(httpContext,cookieKey) ;
			if (cookieValueString != null)
			{
				int result = 0;
				if(int.TryParse(cookieValueString,out result))
				{
				   	return result;
				}
			}
			return null;
		}
	}
}
