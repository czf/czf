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
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Czf.Domain.Global;
using Czf.App.WebAuction.Misc;
using System.IO;
namespace Czf.App.WebAuction
{
	/// <summary>
	/// WebAuction Application methods
	/// </summary>
	public class CzfWebAuction : HttpApplication
	{
		#region Privates
		private static IWindsorContainer container;
		#endregion
		
		/// <summary>
		/// Register routing for WebAuction
		/// </summary>
		/// <param name="routes"></param>
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
//			routes.MapRoute(  //http://stackoverflow.com/questions/3874625/mvc-route-with-array-of-homogeneous-parameters
//			).RouteHandler    //custom handler to handle an array.
			
			routes.MapRoute(
				"Item",
				"item_i{id}",
				new {
					controller = ControllerName.Item,
					action="item"
				},
				new{
					id = @"\d+"
				}
			);
						
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
			BootstrapContainer();
		}
		
		/// <summary>
		/// When this application ends run clean up tasks
		/// </summary>
		protected void Application_End()
		{
    		container.Dispose();
		}
		#region Private Methods
		private static void BootstrapContainer()
		{
			container = new WindsorContainer(new XmlInterpreter());
			WindsorControllerFactory controllerFactory = new WindsorControllerFactory(container.Kernel);
    		ControllerBuilder.Current.SetControllerFactory(controllerFactory);		
		}
		#endregion
	}
}
