using System;
using System.Web.Mvc;

namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Description of UserOptionsController.
	/// </summary>
	public class UserOptionsController : Controller
	{
		/// <summary>
		/// Default action for the logged in user's options
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			
			
			return View();
		}
	}
}