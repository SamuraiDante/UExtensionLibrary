// // -------------------------------------------------------------------------
// // File: Datatables.cs
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
using System;
using System.Data;
using System.IO;

namespace UExtensionLibrary.Datatables
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

            for (int i = inputTable.Rows.Count - 1; i >= 0; i--)
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

        public static object HandleNull(object objRowValue)
        {
            if (objRowValue == DBNull.Value) return null;
            return objRowValue;
        }
         

    }

}