


//get all the files
	//filter out the merge and minify files
//add to appropriate section


using System;
using System.Configuration;
using Czf.Util.Common;
namespace Czf.App.WebAuction
{

	/// <summary>
	/// Constants for application assets
	/// </summary>
	public static class Asset
	{
		//string bleh = @"D:\dev\solutions\czf\C#\Solution\Czf.App.WebAuction\WebAuction\Templates";
	 
		/// <summary>
		/// Constants for application style sheets
		/// </summary>
		public static class Stylesheet
		{
			
			
			static Stylesheet()
			{
			//System.Diagnostics.Debugger.Launch();
				AssetSection assetConfig = (AssetSection)ConfigurationManager.GetSection("assets");

				css_desktop = assetConfig.Stylesheets[@"css\desktop.css"].Location;
				css_mobile = assetConfig.Stylesheets[@"css\mobile.css"].Location;
				css_StyleSheetNotFound = assetConfig.Stylesheets[@"css\stylesheetnotfound.css"].Location;
				css_tablet = assetConfig.Stylesheets[@"css\tablet.css"].Location;
			}

			#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static readonly string css_desktop;
			#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static readonly string css_mobile;
			#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static readonly string css_StyleSheetNotFound;
			#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static readonly string css_tablet;

		}

		/// <summary>
		/// constatns for application script assets 
		/// </summary>
		public static class Script
		{
			
			static Script()
			{
				AssetSection assetConfig = (AssetSection)ConfigurationManager.GetSection("assets");


			}
		}
	  
	  	  	  	  	  
	}

}

