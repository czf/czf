using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using Czf.Mvc.Common.Controllers;
using Czf.Domain.Interfaces.Consumers;


namespace Czf.Mvc.Common.ActionFilters
{
	/// <summary>
	/// Action Filter Attribute for setting the repository properties on form input models.
	/// </summary>
	public class SetInputSourcesAttribute : ActionFilterAttribute
	{

		#region Privates

		

		#endregion

		#region Properties

		
		#endregion

		#region Methods

		/// <summary>
		/// Called by the MVC framework before the action method executes.
		/// Populates the various consumers
		/// </summary>
		/// <param name="filterContext">The filter context.</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			BaseAuctionController controller = filterContext.Controller as BaseAuctionController;
			

			if ((controller != null))
			{
				foreach (KeyValuePair<string, object> parameter in filterContext.ActionParameters)
				{
					IAuctionSourceConsumer auctionConsumer = parameter.Value as IAuctionSourceConsumer;
					if (auctionConsumer != null)
						auctionConsumer .AuctionSource = controller.AuctionSource;


				}
			}
		}

		#endregion

	}
}
