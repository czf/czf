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
	[SetupAuctionSession]
	public class GlobalAuctionController : BaseAuctionController
	{
		public void main()
		{
			
		}
	}
}