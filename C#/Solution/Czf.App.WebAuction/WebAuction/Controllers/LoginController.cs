using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.AuctionObjects;
using Czf.App.WebAuction.Models;
using Czf.App.WebAuction.Models.InputViewModel;
using Czf.Mvc.Common.ActionFilters;
using Czf.Mvc.Common.Controllers;

using System.IO;
namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Description of Login.
	/// </summary>
	public class LoginController : BaseAuctionController
	{

		/// <summary>
		/// Setup the inital login page
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{			
			IEnumerable<string> directories = Directory.EnumerateDirectories(".");
			
			LoginActionViewModel model = new LoginActionViewModel();
			return View("Login",model);
		}
		
		/// <summary>
		/// Validates a user login.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[SetInputSources]
		public ActionResult LoginAction(LoginActionInputModel input)
		{
			User user = null;
			if (input.CheckValidity()) {
				user = input.SubmittedUser;
				//Set user state/cookies
			}
			return View("LoggedIn", new LoginActionViewModel());
		}
	}
}