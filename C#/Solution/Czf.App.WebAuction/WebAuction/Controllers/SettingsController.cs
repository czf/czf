using System;
using System.Web.Mvc;

namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Description of SettingsController.cs.
	/// </summary>
	public class SettingsController : Controller
	{
		/// <summary>
		/// Setup initial Settings interface
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			return View();
		}
	}
}