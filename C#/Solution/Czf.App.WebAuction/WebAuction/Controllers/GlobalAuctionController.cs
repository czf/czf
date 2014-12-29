using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Czf.Domain.Interfaces.Consumers;

using Czf.Mvc.Common.Controllers;
using Czf.App.WebAuction.ActionFilters;
namespace Czf.App.WebAuction.Controllers
{
	/// <summary>
	/// Description of GlobalAuctionController.
	/// </summary>
	[SetupAuctionSession(Order=1)]
	[RedirectToLogin(Order=2)]
	public class GlobalAuctionController : BaseAuctionController
	{
		/// <summary>
		/// Create an instance of GlobalAuctionController
		/// </summary>
		public GlobalAuctionController()
		{
			
		}
		
		/// <summary>
		/// Creates a redirect to the login action
		/// </summary>
		public RedirectToRouteResult RedirectToLogin()
		{
			return RedirectToAction("Index",ControllerName.Login);
		}
	}
}