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
namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Controller for initial page
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// Setup intial page.
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			return View();
		}
		
		
		
	}
}
