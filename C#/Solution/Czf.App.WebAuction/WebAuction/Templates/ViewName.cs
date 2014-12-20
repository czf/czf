using System;

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
		public static class Login
		{
			/// <summary>Full Views for this directory</summary>
			public static class FullView
			{				
				/// <summary>String constant for the Index View.</summary>
				public static readonly string Index = "Index";
			}
		}

		/// <summary>Directory</summary>
		public static class Shared
		{
			/// <summary>Directory</summary>
			public static class Footer
			{ 
	 			///<summary>Partial Views for this directory</summary>
	 			public static class PartialView
	 			{				
					/// <summary>String constant for the _footer partial.</summary>
					public static readonly string _footer = "_footer";				
				}
			}

			/// <summary>Directory</summary>
			public static class Header
			{
				/// <summary>Directory</summary>
				public static class DepthTest
				{
					/// <summary>Full Views for this directory</summary>
					public static class FullView
					{				
						/// <summary>String constant for the depthTestView View.</summary>
						public static readonly string depthTestView = "depthTestView";
					}
				}

				/// <summary>Directory</summary>
				public static class SameDepthTest
				{
					/// <summary>Full Views for this directory</summary>
					public static class FullView
					{				
						/// <summary>String constant for the sameDepthTest View.</summary>
						public static readonly string sameDepthTest = "sameDepthTest";
					}
				}
 
	 			///<summary>Partial Views for this directory</summary>
	 			public static class PartialView
	 			{				
					/// <summary>String constant for the _header partial.</summary>
					public static readonly string _header = "_header";				
				}
			}
 
 			///<summary>Partial Views for this directory</summary>
 			public static class PartialView
 			{				
				/// <summary>String constant for the _LayoutPage partial.</summary>
				public static readonly string _LayoutPage = "_LayoutPage";				
			}
		}
 
	}
}