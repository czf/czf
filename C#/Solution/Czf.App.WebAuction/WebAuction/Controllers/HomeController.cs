/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/15/2012
 * Time: 3:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web.Mvc;
using System.Text.RegularExpressions;
namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Controller for initial page
	/// </summary>
	public class HomeController : GlobalAuctionController
	{
		/// <summary>
		/// Setup intial page.
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			Regex reg = new Regex("^.+/.(/n)+/.css$",RegexOptions.IgnoreCase);
			reg.IsMatch("global.500.css");
			
			return View();
		}
		
		
		
	}
}
