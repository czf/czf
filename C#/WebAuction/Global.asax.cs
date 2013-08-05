/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/15/2012
 * Time: 3:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Czf.Domain.Global;
namespace Czf.App.WebAuction
{
	public class CzfWebAuction : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");
			
			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new {
					controller = "Home",
					action = "Index",
					id = UrlParameter.Optional
				});
		}
		
		/// <summary>
		/// Executed once per running web application instance startup.
		/// </summary>		
		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
		}
	}
}
