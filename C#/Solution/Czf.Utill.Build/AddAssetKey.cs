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
	public class AddAssetKey : Task
	{
		#region Properties

		/// <summary>
		/// Gets or sets the input files.
		/// </summary>
		/// <value>The input files.</value>
		[Required]
		public ITaskItem[] InputFiles { get; set; }

		/// <summary>
		/// Gets or sets the output files.
		/// </summary>
		/// <value>The output files.</value>
		[Output]
		public ITaskItem[] OutputFiles { get; private set; }

		#endregion

		#region Methods

        /// <summary>
        /// Executes the AddAssetKey task.
        /// </summary>
        /// <returns>
        /// true if the task successfully executed; otherwise, false.
        /// </returns>
		public override bool Execute()
		{
			OutputFiles = InputFiles;
			foreach (ITaskItem file in OutputFiles)
			{
				file.SetMetadata("AssetKey", file.ItemSpec.ToLowerInvariant());
				switch (file.GetMetadata("Extension").ToLowerInvariant())
				{
					case ".css":
						file.SetMetadata("AssetSection", "stylesheets");
						break;
					case ".js":
						file.SetMetadata("AssetSection", "scripts");
						break;
					case ".swf":
						file.SetMetadata("AssetSection", "flashFiles");
						break;
                    case ".xsl":
                        file.SetMetadata("AssetSection", "xslFiles");
                        break;
					default:
						break;
				}
			}
			return true;
		}

		#endregion

	}

}
