/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/24/2014
 * Time: 5:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using System.Web.Routing;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
namespace Czf.App.WebAuction.Misc
{
	/// <summary>
	/// Description of WindsorControllerFactory.
	/// </summary>
	public class WindsorControllerFactory : DefaultControllerFactory
	{
		#region Privates
		private readonly IKernel _kernel;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		
		/// <summary>
		/// Create an instance of WindsorControllerFactory.
		/// </summary>
		public WindsorControllerFactory(IKernel kernel)
		{
			_kernel = kernel;
			var controllerTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IController).IsAssignableFrom(t));
//			foreach (Type t in controllerTypes)
//				_kernel.Register(Castle.MicroKernel.Registration.Component.For(t).Named(t.FullName).LifeStyle.Is(LifestyleType.Transient));
			
			// All controllers in Czf.App.WebAuction
			_kernel.Register(Classes.FromThisAssembly()
                            .BasedOn<IController>()
                            .LifestyleTransient());
		}
		#endregion
		#region Methods
		/// <summary>
		/// Perform clean on the controller on release.
		/// </summary>
		/// <param name="controller"></param>
		public override void ReleaseController(IController controller)
		{
			_kernel.ReleaseComponent(controller);
			base.ReleaseController(controller);
		}
		
		/// <summary>
		/// Retrieves the controller instance for the specified request context and controller type and resolves registered types.
		/// </summary>
		/// <param name="requestContext"></param>
		/// <param name="controllerType"></param>
		/// <returns></returns>
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if(controllerType == null)
			{
				throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
			}
			return (IController)_kernel.Resolve(controllerType);
		}
		#endregion
	}
}
