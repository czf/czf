using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Ols.Core.Util.Build
{


	/// <summary>
	/// Adds Asset config metadata to a file list.
	/// </summary>
	public class SortItems : Task
	{
		#region Properties

		/// <summary>
		/// Gets or sets the input list of files.
		/// </summary>
		/// <value>The input list.</value>
		[Required]
		public ITaskItem[] InputFileList { get; set; }

		/// <summary>
		/// Gets or sets the output list of items.
		/// </summary>
		/// <value>The output list.</value>
		[Output]
		public ITaskItem[] OutputFileList { get; private set; }

		#endregion

		#region Methods

        /// <summary>
		/// Executes the SortItems task.
        /// </summary>
        /// <returns>
        /// true if the task successfully executed; otherwise, false.
        /// </returns>
		public override bool Execute()
		{
			OutputFileList = InputFileList;
			Array.Sort(OutputFileList, new ITaskItemComparer());
			return true;
		}

		#endregion

		#region IComparer

		/// <summary>
		/// Sorts TaskItems based on filename
		/// </summary>
		private class ITaskItemComparer : IComparer<ITaskItem>
		{
			/// <summary>
			/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
			/// </summary>
			/// <param name="x">The first object to compare.</param>
			/// <param name="y">The second object to compare.</param>
			/// <returns>
			/// Value
			/// Condition
			/// Less than zero
			/// <paramref name="x"/> is less than <paramref name="y"/>.
			/// Zero
			/// <paramref name="x"/> equals <paramref name="y"/>.
			/// Greater than zero
			/// <paramref name="x"/> is greater than <paramref name="y"/>.
			/// </returns>
			public int Compare(ITaskItem x, ITaskItem y)
			{
				string xFilename = x.ItemSpec.ToLowerInvariant();
				if (xFilename.Contains(@"\"))
					xFilename = xFilename.Substring(xFilename.LastIndexOf(@"\") + 1);
				string yFilename = y.ItemSpec.ToLowerInvariant();
				if (yFilename.Contains(@"\"))
					yFilename = yFilename.Substring(yFilename.LastIndexOf(@"\") + 1);

				string desktopPrefix = "desktop.";
				string globalPrefix = "global.";
				string mobilePrefix = "mobile.";
				string tabletPrefix = "tablet.";

				bool xMergeable = (xFilename.StartsWith(desktopPrefix) || xFilename.StartsWith(globalPrefix) || xFilename.StartsWith(mobilePrefix) || xFilename.StartsWith(tabletPrefix));
				bool yMergeable = (yFilename.StartsWith(desktopPrefix) || yFilename.StartsWith(globalPrefix) || yFilename.StartsWith(mobilePrefix) || yFilename.StartsWith(tabletPrefix));
				
				if (xMergeable && yMergeable)
				{
					string[] mergeables = new string[] { desktopPrefix, globalPrefix, mobilePrefix, tabletPrefix };
					return StripPrefix(xFilename, mergeables).CompareTo(StripPrefix(yFilename, mergeables));
				}
				return xFilename.CompareTo(yFilename);
			}
		}

		/// <summary>
		/// Strips the prefixes "desktop.", "global.", "mobile.", and "tablet." from the filename of the target.
		/// </summary>
		/// <param name="target">The target.</param>
		/// <param name="mergeables">The mergeables.</param>
		/// <returns>
		/// Prefix-stripped string, or string.empty if null/empty.
		/// </returns>
		private static string StripPrefix(string target, string[] mergeables)
		{
			string result = target;
			if ((mergeables != null && mergeables.Count() > 0) && ((result ?? string.Empty) != string.Empty) || ((result.Trim().Length > 0)))
			{
				foreach (string global in mergeables)
				{
					if (result.StartsWith(global))
					{
						result = result.Substring(target.IndexOf(global) + global.Length);
						break;
					}
				}
			}
			return result;
		}

		#endregion
	}

}
