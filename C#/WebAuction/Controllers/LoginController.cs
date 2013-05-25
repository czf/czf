using System;
using System.Web.Mvc;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.AuctionObjects;
using WebAuction.Models;

namespace WebAuction.Controllers
{
	/// <summary>
	/// Description of Login.
	/// </summary>
	public class Login : Controller
	{
		/// <summary>
		/// Source for Auction Data
		/// </summary>
		IAuctionSource AuctionSource {get; set;} 
		
		public ActionResult Index()
		{			
			return View();
		}
		
		/// <summary>
		/// Accepts valid login usernames
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		public ActionResult LoginAction(int? username)
		{
			User user = null;
			if (username.HasValue) {
				user = AuctionSource.Get<User>(username.Value);
				//Set user state/cookies
			
			}
			return View("LoggedIn", new LoginActionViewModel());
		}
	}
}