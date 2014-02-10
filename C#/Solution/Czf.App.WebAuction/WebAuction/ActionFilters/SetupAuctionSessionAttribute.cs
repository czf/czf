using System;
using System.Web;
using System.Web.Mvc;
using Czf.Domain.AuctionObjects;
using Czf.Domain.AuctionObjects.AuctionSessionObjects;
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
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			IHasAuctionSession controller = filterContext.Controller as IHasAuctionSession;
			if(controller!= null)
			{
				AuctionSession session = new AuctionSession();
				if(controller.AuctionSource != null)
				{
					session.AuctionSource = controller.AuctionSource;
				}
				
				_auctionCookie = filterContext.HttpContext.Request.Cookies[_auctionCookieKey] ?? new HttpCookie(_auctionCookieKey);
				
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
		
	}
}
