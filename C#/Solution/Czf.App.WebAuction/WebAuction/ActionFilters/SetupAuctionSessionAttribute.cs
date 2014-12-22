using System;
using System.Web;
using System.Web.Mvc;
using Czf.Domain.AuctionObjects;
using Czf.Domain.AuctionObjects.AuctionSessionObjects;
using Czf.App.WebAuction.Controllers;
using Czf.Domain.Interfaces;
using Czf.Domain;
using Czf.Util.Common;

namespace Czf.App.WebAuction.ActionFilters
{
	/// <summary>
	/// Description of SetupSessionAttribute.
	/// </summary>
	public class SetupAuctionSessionAttribute : ActionFilterAttribute
	{
		#region Privates
		private static readonly string _auctionCookieKey = "AU";
		private static readonly string _auctionCookieUserIdKey = "u";
		private HttpCookie _auctionCookie {get; set;}
		#endregion
		/// <summary>
		/// before the action is executed setup the Session data available.
		/// </summary>
		/// <param name="filterContext"></param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			GlobalAuctionController controller = filterContext.Controller as GlobalAuctionController;
			if(controller!= null)
			{
				AuctionSession session = new AuctionSession();
				if(controller.AuctionSource != null)
				{
					session.AuctionSource = controller.AuctionSource;
				}
				
				_auctionCookie = filterContext.HttpContext.Request.Cookies[_auctionCookieKey] ?? new HttpCookie(_auctionCookieKey);
				_auctionCookie.Path = "/";
				//TODO: functionalize this uid get
				if(_auctionCookie != null)
				{
					int? uid = _auctionCookie.FetchCookieValueAsInt(filterContext.HttpContext,_auctionCookieUserIdKey);
					if(uid.HasValue)
					{
						session.User = controller.AuctionSource.Get<User>(uid.Value);
						
					}
				}
				
				
				controller.AuctionSession = session;
			}
			
		}
		
		/// <summary>
		/// After the action is executed perform relevat actions on the Auction Session. 
		/// </summary>
		/// <param name="filterContext"></param>
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			IHasAuctionSession controller = filterContext.Controller as IHasAuctionSession;
			if(controller != null)
			{
				if(controller.AuctionSession != null)
				{
					_auctionCookie = filterContext.HttpContext.Request.Cookies[_auctionCookieKey] ?? new HttpCookie(_auctionCookieKey);
					_auctionCookie.Expires = DateTime.Now.Add(new TimeSpan(4,0,0));
					filterContext.HttpContext.Response.Cookies.Add(_auctionCookie);
				}
				
			}
		}
		
	}
}
