using System;
using System.Web;
using System.Web.Mvc;
using Czf.App.WebAuction.Controllers;
namespace Czf.App.WebAuction.ActionFilters
{
	/// <summary>
	/// Description of RedirectToLoginAttribute.
	/// </summary>
	public class RedirectToLoginAttribute : ActionFilterAttribute
	{
		#region Privates
		#endregion
		#region Properties
		#endregion
		#region Constructors
		#endregion
		#region Methods
		/// <summary>
		/// before the action is executed setup the Session data available.
		/// Determins if the request is from a logged in user.  Redirects to login action
		/// if they aren't
		/// </summary>
		/// <param name="filterContext"></param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			GlobalAuctionController controller = filterContext.Controller as GlobalAuctionController;
			
			if(controller!= null && controller.AuctionSession.User == null 
			   && (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != ControllerName.Login
			      ||
			      (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == ControllerName.Login
			       && filterContext.ActionDescriptor.ActionName != "Index" 
			       && filterContext.ActionDescriptor.ActionName != "LoginAction")
			     ))
			{
				filterContext.Result = controller.RedirectToLogin();
			}
		}
		#endregion
	}
}
