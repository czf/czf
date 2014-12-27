using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Czf.Domain.AuctionObjects;
using Czf.App.WebAuction.Models;
using Czf.App.WebAuction.Models.InputViewModel;
using Czf.Mvc.Common.ActionFilters;

namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Description of Login.
	/// </summary>
	public class LoginController : GlobalAuctionController
	{

		/// <summary>
		/// Setup the inital login page
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult Index()
		{			
			LoginActionViewModel model = new LoginActionViewModel(AuctionSession.User);
			return View("Login",model);
		}
		
		/// <summary>
		/// Validates a user login.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[SetInputSources]
		[HttpPost]
		public ActionResult LoginAction(LoginActionInputModel input)
		{
			User user = null;
			ActionResult result = null;
			if (input.CheckValidity()) {
				user = input.SubmittedUser;
				//Set user state/cookies
				AuctionSession.User = user;
				result = RedirectToAction("Index",ControllerName.Home);
			}
			else
			{
				result = View("LoggedIn", new LoginActionViewModel(input)); 
			}
			
			return result;
		}
	}
}