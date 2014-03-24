using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Ols.Core.Util.Build
{
	/// <summary>
	/// Writes asset configuration data to the target xml file.
	/// </summary>
	public class BuildAssetConfig : Task
	{
		#region Privates

		#endregion

		#region Properties

		/// <summary>
		/// Sets the input files.
		/// </summary>
		/// <value>The input files.</value>
		[Required]
		public ITaskItem[] InputFiles { get; set; }

		/// <summary>
		/// (Optional) Gets or sets the global/desktop CSS file.
		/// </summary>
		/// <value>The global/desktop CSS output file.</value>
		public string DesktopCssFile { get; set; }

		/// <summary>
		/// (Optional) Gets or sets the global/mobile CSS file.
		/// </summary>
		/// <value>The global/mobile CSS output file.</value>
		public string MobileCssFile { get; set; }

		/// <summary>
		/// (Optional) Gets or sets the global/desktop/tablet CSS file.
		/// </summary>
		/// <value>The global/dektop/tablet CSS output file.</value>
		public string TabletCssFile { get; set; }

		/// <summary>
		/// (Optional) Gets or sets the global/desktop script file.
		/// </summary>
		/// <value>The global/desktop script output file.</value>
		public string DesktopScriptFile { get; set; }

		/// <summary>
		/// (Optional) Gets or sets the global/mobile script file.
		/// </summary>
		/// <value>The global/mobile script output file.</value>
		public string MobileScriptFile { get; set; }

		/// <summary>
		/// (Optional) Gets or sets the global/desktop/tablet script file.
		/// </summary>
		/// <value>The global/desktop/tablet script output file.</value>
		public string TabletScriptFile { get; set; }

        /// <summary>
        /// Sets the output file.
        /// </summary>
        /// <value>The output file.</value>
		[Required]
		public string OutputFile { get; set; }

		#endregion

		#region Methods

        /// <summary>
        /// Executes the BuildAssetConfig task.
        /// </summary>
        /// <returns>
        /// true if the task successfully executed; otherwise, false.
        /// </returns>
		public override bool Execute()
		{
			Console.WriteLine("*******************************************************************************************HERE");
			XmlDocument assetsXml = new XmlDocument();
			assetsXml.AppendChild(assetsXml.CreateXmlDeclaration("1.0", "utf-8", null));
			Dictionary<string, XmlNode> sections = new Dictionary<string,XmlNode>();
            string assetSection;
			XmlNode assetsRoot = assetsXml.CreateNode(XmlNodeType.Element, "assets", "");
			XmlNode assetNode;
			XmlAttribute original;
			XmlAttribute location;
			if ((DesktopCssFile != null) && (DesktopCssFile.Length > 0))
			{
				if (!sections.ContainsKey("stylesheets"))
				{
					sections["stylesheets"] = assetsXml.CreateNode(XmlNodeType.Element, "stylesheets", "");
				}
				assetNode = assetsXml.CreateNode(XmlNodeType.Element, "asset", "");
				original = assetsXml.CreateAttribute("original");
				original.Value = @"css\desktop.css";
				location = assetsXml.CreateAttribute("location");
				location.Value = DesktopCssFile.Replace(@"\", "/");
				assetNode.Attributes.Append(original);
				assetNode.Attributes.Append(location);
				sections["stylesheets"].AppendChild(assetNode);
			}

			if ((MobileCssFile != null) && (MobileCssFile.Length > 0))
			{
				if (!sections.ContainsKey("stylesheets"))
				{
					sections["stylesheets"] = assetsXml.CreateNode(XmlNodeType.Element, "stylesheets", "");
				}
				assetNode = assetsXml.CreateNode(XmlNodeType.Element, "asset", "");
				original = assetsXml.CreateAttribute("original");
				original.Value = @"css\mobile.css";
				location = assetsXml.CreateAttribute("location");
				location.Value = MobileCssFile.Replace(@"\", "/");
				assetNode.Attributes.Append(original);
				assetNode.Attributes.Append(location);
				sections["stylesheets"].AppendChild(assetNode);
			}

			if ((TabletCssFile != null) && (TabletCssFile.Length > 0))
			{
				if (!sections.ContainsKey("stylesheets"))
				{
					sections["stylesheets"] = assetsXml.CreateNode(XmlNodeType.Element, "stylesheets", "");
				}
				assetNode = assetsXml.CreateNode(XmlNodeType.Element, "asset", "");
				original = assetsXml.CreateAttribute("original");
				original.Value = @"css\tablet.css";
				location = assetsXml.CreateAttribute("location");
				location.Value = TabletCssFile.Replace(@"\", "/");
				assetNode.Attributes.Append(original);
				assetNode.Attributes.Append(location);
				sections["stylesheets"].AppendChild(assetNode);
			}

			if ((DesktopScriptFile != null) && (DesktopScriptFile.Length > 0))
			{
				if (!sections.ContainsKey("scripts"))
				{
					sections["scripts"] = assetsXml.CreateNode(XmlNodeType.Element, "scripts", "");
				}
				assetNode = assetsXml.CreateNode(XmlNodeType.Element, "asset", "");
				original = assetsXml.CreateAttribute("original");
				original.Value = @"scripts\desktop.js";
				location = assetsXml.CreateAttribute("location");
				location.Value = DesktopScriptFile.Replace(@"\", "/");
				assetNode.Attributes.Append(original);
				assetNode.Attributes.Append(location);
				sections["scripts"].AppendChild(assetNode);
			}

			if ((MobileScriptFile != null) && (MobileScriptFile.Length > 0))
			{
				if (!sections.ContainsKey("scripts"))
				{
					sections["scripts"] = assetsXml.CreateNode(XmlNodeType.Element, "scripts", "");
				}
				assetNode = assetsXml.CreateNode(XmlNodeType.Element, "asset", "");
				original = assetsXml.CreateAttribute("original");
				original.Value = @"scripts\mobile.js";
				location = assetsXml.CreateAttribute("location");
				location.Value = MobileScriptFile.Replace(@"\", "/");
				assetNode.Attributes.Append(original);
				assetNode.Attributes.Append(location);
				sections["scripts"].AppendChild(assetNode);
			}

			if ((TabletScriptFile != null) && (TabletScriptFile.Length > 0))
			{
				if (!sections.ContainsKey("scripts"))
				{
					sections["scripts"] = assetsXml.CreateNode(XmlNodeType.Element, "scripts", "");
				}
				assetNode = assetsXml.CreateNode(XmlNodeType.Element, "asset", "");
				original = assetsXml.CreateAttribute("original");
				original.Value = @"scripts\tablet.js";
				location = assetsXml.CreateAttribute("location");
				location.Value = TabletScriptFile.Replace(@"\", "/");
				assetNode.Attributes.Append(original);
				assetNode.Attributes.Append(location);
				sections["scripts"].AppendChild(assetNode);
			}

			foreach (ITaskItem file in InputFiles)
			{
				if (file.GetMetadata("AssetKey").Length > 0)
				{
					assetNode = assetsXml.CreateNode(XmlNodeType.Element, "asset", "");
					original = assetsXml.CreateAttribute("original");
					original.Value = file.GetMetadata("AssetKey");
					location = assetsXml.CreateAttribute("location");
					if (file.GetMetadata("SvnRevisionAndStatus").Length > 0)
					{
						location.Value = file.GetMetadata("RelativeDir")
										+ file.GetMetadata("FileName")
										+ "."
										+ file.GetMetadata("SvnRevisionAndStatus")
										+ file.GetMetadata("Extension");
					}
					else
					{
						location.Value = file.ItemSpec;
					}
					location.Value = location.Value.Replace(@"\","/");
					assetNode.Attributes.Append(original);
					assetNode.Attributes.Append(location);
                    assetSection = file.GetMetadata("AssetSection");
                    if (!sections.ContainsKey(assetSection))
                    {
                        sections[assetSection] = assetsXml.CreateNode(XmlNodeType.Element, assetSection, "");
                    }
                    sections[assetSection].AppendChild(assetNode);
				}
			}
            foreach (XmlNode xmlSection in sections.Values)
            {
                assetsRoot.AppendChild(xmlSection);
            }
			assetsXml.AppendChild(assetsRoot);
			assetsXml.Save(OutputFile);
			return true;
		}

		#endregion

	}

}
