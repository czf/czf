﻿using System;
using System.Web.Mvc;
using Czf.Domain.Interfaces.Consumers;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.AuctionObjects.AuctionSessionObjects;
using Czf.Domain.Interfaces;
namespace Czf.Mvc.Common.Controllers
{
	/// <summary>
	/// Description of BaseAuctionController.
	/// </summary>
	public abstract class BaseAuctionController : Controller, IAuctionSourceConsumer, IHasAuctionSession, IAuctionSettingsConsumer
	{
		/// <summary>
		/// A reference to an IAuctionSource
		/// </summary>
		public IAuctionSource AuctionSource {get; set;}
		
		/// <summary>
		/// A reference to an IAuctionSettings
		/// </summary>
		public IAuctionSettings AuctionSettings {get; set;}
		
		/// <summary>
		/// Auction data relating to this session;
		/// </summary>
		public AuctionSession AuctionSession {get; set;}
	}
}