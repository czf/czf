using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Czf.Util.Common
{
	public class AssetSection : ConfigurationSection
	{
		[ConfigurationProperty("stylesheets")]
		[ConfigurationCollection(typeof(AssetCollection), AddItemName = "asset")]
		public AssetCollection Stylesheets
		{
			get
			{
				AssetCollection collection= (AssetCollection)base["stylesheets"];
				return collection;
			}
		}

		[ConfigurationProperty("scripts")]
		[ConfigurationCollection(typeof(AssetCollection), AddItemName = "asset")]
		public AssetCollection Scripts
		{
			get
			{
				AssetCollection collection = (AssetCollection)base["scripts"];
				return collection;
			}
		}
	}

	public class AssetCollection : ConfigurationElementCollection
	{
		public AssetCollection()
		{
			AssetElement asset = (AssetElement)CreateNewElement();
			BaseAdd(asset);
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new AssetElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((AssetElement)element).Original;
		}
		protected override void BaseAdd(ConfigurationElement element)
		{
			BaseAdd(element, false);
		}
		
		new public AssetElement this[string Name]
		{
			get
			{
				return (AssetElement)BaseGet(Name);
			}
			
		}
	}

	public class AssetElement : ConfigurationElement
	{
		public AssetElement()
		{
		}
		/// <summary>
		/// Original location
		/// </summary>
		[ConfigurationProperty("original",IsKey =true)]
		public string Original
		{
			get
			{
				return (string)this["original"];
			}
			set
			{
				this["original"] = value;
			}
		}

		/// <summary>
		/// Built location
		/// </summary>
		[ConfigurationProperty("location")]
		public string Location
		{
			get
			{
				return (string)this["location"];
			}
			set
			{
				this["location"] = value;
			}
		}
	}
}
