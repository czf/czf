﻿using System;

namespace Czf.App.WebAuction
{
	///<summary> Static class for view names</summary>
	public static class ViewName 
	{
		/// <summary>Directory</summary>
		public static class Home
		{
			/// <summary>Full Views for this directory</summary>
			public static class FullView
			{				
				/// <summary>String constant for the Contact View.</summary>
				public static readonly string Contact = "Contact";				
				/// <summary>String constant for the Index View.</summary>
				public static readonly string Index = "Index";
			}
		}

		/// <summary>Directory</summary>
		public static class Item
		{
			/// <summary>Full Views for this directory</summary>
			public static class FullView
			{				
				/// <summary>String constant for the Item View.</summary>
				public static readonly string Item = "Item";
			}
		}

		/// <summary>Directory</summary>
		public static class ItemList
		{
			/// <summary>Full Views for this directory</summary>
			public static class FullView
			{				
				/// <summary>String constant for the List View.</summary>
				public static readonly string List = "List";
			}
		}

		/// <summary>Directory</summary>
		public static class Login
		{
			/// <summary>Full Views for this directory</summary>
			public static class FullView
			{				
				/// <summary>String constant for the LoggedIn View.</summary>
				public static readonly string LoggedIn = "LoggedIn";				
				/// <summary>String constant for the Login View.</summary>
				public static readonly string Login = "Login";
			}
		}

		/// <summary>Directory</summary>
		public static class Shared
		{ 
 			///<summary>Partial Views for this directory</summary>
 			public static class PartialView
 			{				
				/// <summary>String constant for the _LayoutPage partial.</summary>
				public static readonly string _LayoutPage = "_LayoutPage";				
			}
		}
 
	}
}