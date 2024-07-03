// // -------------------------------------------------------------------------
// // File: Datatables.cs
// // Author: Hughes, Donivan
// // Abstract: TODO: Add abstract
// //
// // Created: 07/12/2016 10:36 AM
// // Last Updated:  10:36 AM
// // -------------------------------------------------------------------------
//
// // -------------------------------------------------------------------------
// // Imports
// // -------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using Microsoft.CSharp;

namespace UExtensionLibrary.Extensions
{
	public static class Datatables
	{
		/// ------------------------------------------------------------------------------------------
		///  Name: ReverseRows
		///  ------------------------------------------------------------------------------------------
		/// <summary> Reverses the datarows of the specified table. </summary>
		/// <param name="inputTable">Table to affect</param>
		/// <returns>DataTable.</returns>
		///  ------------------------------------------------------------------------------------------
		public static DataTable ReverseRows(this DataTable inputTable)
		{
			DataTable outputTable = inputTable.Clone();

			for(int i = inputTable.Rows.Count - 1; i >= 0; i--)
			{
				outputTable.ImportRow(inputTable.Rows[i]);
			}

			return outputTable;
		}

		/// ------------------------------------------------------------------------------------------
		///  Name: ToXML
		///  ------------------------------------------------------------------------------------------
		/// <summary> Converts datatable to XML </summary>
		/// <param name="dtInput">The data table to convert.</param>
		/// <returns>System.String.</returns>
		///  ------------------------------------------------------------------------------------------
		public static string ToXML(this DataTable dtInput)
		{
			StringWriter objCurrentWriter = new StringWriter();

			//Write datatable as XML
			dtInput.WriteXml(objCurrentWriter);

			//Return XML
			return objCurrentWriter.ToString();
		}

        /// ------------------------------------------------------------------------------------------
        ///  Name: HandleNull
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Handles the possibility of DBNull </summary>
        /// <param name="objRowValue">The value to handle.</param>
        /// <returns>Returns <paramref name="objRowValue"/> or returns null if value is DBNull.</returns>
        ///  ------------------------------------------------------------------------------------------

        public static object HandleNull(object objRowValue)
		{
			if(objRowValue == DBNull.Value)
				return null;
			return objRowValue;
		}

        /// ------------------------------------------------------------------------------------------
        ///  Name: FirstValue
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Gets the first value from the DataTable. </summary>
        /// <param name="dtToExtend">The DataTable to extend.</param>
        /// <returns>The first value from the DataTable.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static object FirstValue(this DataTable dtToExtend)
        {
            object objReturnValue = null;
            if (dtToExtend.Rows.Count > 0)
            {
                if (dtToExtend.Columns.Count > 0)
                {
                    objReturnValue = dtToExtend.Rows[0][0];
                }
                else
                {
                    throw new InvalidOperationException("Can not get first value of datatable. Datatable has rows, but has no columns.");
                }
            }
            else
            {
                throw new InvalidOperationException("Can not get first value of datatable. Datatable has no rows.");
            }

            return objReturnValue;
        }

        /// <summary>
        /// Converts a DataTable to an HTML table.
        /// </summary>
        /// <param name="dt">The DataTable to convert.</param>
        /// <returns>The HTML representation of the DataTable.</returns>
        public static string ToHTML(DataTable dt)
        {
            string html = "<table>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

        /// <summary>
        /// Converts a list of dynamic objects to a DataTable.
        /// </summary>
        /// <param name="objList">The list of dynamic objects.</param>
        /// <returns>The converted DataTable.</returns>
        public static DataTable FromDynamicList(List<dynamic> objList)
        {
            DataTable dt = new DataTable();
            if (objList != null && objList.Count > 0)
            {
                foreach (var Property in objList.First())
                {
                    if (dt.Columns.Contains(Property.Key) == false)
                        dt.Columns.Add(Property.Key);
                }
                foreach (var Item in objList)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var Prop in Item)
                    {
                        dr[Prop.Key] = Prop.Value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
	}
}
