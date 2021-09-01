using HtmlAgilityPack;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace UExtensionLibrary.Extensions
{
	public static class HTML
	{
		/// <summary>
		/// Parses html string into an XElement
		/// </summary>
		/// <param name="html"></param>
		/// <returns>XElement representing the outermost parent</returns>
		public static XElement HTMLToXElement(string html)
		{
			if(html == null)
				throw new ArgumentNullException("html");

			HtmlDocument doc = new HtmlDocument();
			doc.OptionOutputAsXml = true;
			doc.LoadHtml(html);
			using(StringWriter writer = new StringWriter())
			{
				doc.Save(writer);
				using(StringReader reader = new StringReader(writer.ToString()))
				{
					return XElement.Load(reader);
				}
			}
		}
	}
}
