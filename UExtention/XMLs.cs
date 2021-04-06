// // -------------------------------------------------------------------------
// // File: XML.cs
// // Author: Hughes, Donivan(hughes.dh.1)
// // Abstract: TODO: Add abstract
// //
// // Created: 07/12/2016 10:36 AM
// // Last Updated: 07/12/2016 10:36 AM
// // -------------------------------------------------------------------------
// 
// // -------------------------------------------------------------------------
// // Imports
// // -------------------------------------------------------------------------
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace UExtensionLibrary.XML
{

    public static class XML
    {

        /// ------------------------------------------------------------------------------------------
        ///  Name: GetFirstInstanceAndRename
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Gets the first instance of the specified tag and renames it, preserving the data. </summary>
        /// <param name="lxelToSearch">The XElement to search.</param>
        /// <param name="strNewName">The string used to rename the tag</param>
        /// <param name="strValueNodeName">string name of the Tag to find</param>
        /// <returns>XElement.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static XElement GetFirstInstanceAndRename(this IEnumerable<XElement> lxelToSearch, string strNewName, string strValueNodeName)
        {
            XElement xelNewNode = new XElement(strNewName);
            XElement xelValue = lxelToSearch.Elements(strValueNodeName).FirstOrDefault();
            xelNewNode.Value = xelValue != null ? xelValue.Value : "";
            return xelNewNode;
        }
        /// ------------------------------------------------------------------------------------------
        ///  Name: GetFirstOrEmpty
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Gets the first instance of the specified tag, or returns a new tag with the specifeid name it one can not be found.</summary>
        /// <param name="lxelToSearch">The XElement to search.</param>
        /// <param name="strNodeName">Name of the tag to find.</param>
        /// <returns>XElement.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static XElement GetFirstOrEmpty(this IEnumerable<XElement> lxelToSearch, string strNodeName)
        {
            XElement xelNewNode = new XElement(strNodeName);
            XElement xelValue = lxelToSearch.Elements(strNodeName).FirstOrDefault();
            xelNewNode.Value = xelValue != null ? xelValue.Value : "";
            return xelNewNode;
        } 

    }

}