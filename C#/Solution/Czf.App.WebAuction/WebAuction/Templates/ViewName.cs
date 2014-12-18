using System;

namespace Czf.App.WebAuction
{
	///<summary> Static class for view names</summary>
	public static class ViewName 
	{
 		public static class Home
 		{
 			public static class Partials
 			{					
			}
			public static class FullView
			{				
				/// <summary>String constant for the Contact View.</summary>
				public static readonly string Contact = "Contact";			
				/// <summary>String constant for the Index View.</summary>
				public static readonly string Index = "Index";			
			}
		}
 		public static class Login
 		{
 			public static class Partials
 			{					
			}
			public static class FullView
			{				
				/// <summary>String constant for the Index View.</summary>
				public static readonly string Index = "Index";			
			}
		}
 		public static class Shared
 		{
 			public static class Partials
 			{				
				/// <summary>String constant for the _LayoutPage partial.</summary>
				public static readonly string _LayoutPage = "_LayoutPage";				
			}
			public static class FullView
			{				
			}
		}
 
	}
}