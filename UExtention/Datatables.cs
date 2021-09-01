﻿// // -------------------------------------------------------------------------
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

		/// <summary>
		/// Handles the possibility of DBNull
		/// </summary>
		/// <param name="objRowValue"></param>
		/// <returns>Returns <paramref name="objRowValue"/> or returns null if value is DBNull </returns>
		public static object HandleNull(object objRowValue)
		{
			if(objRowValue == DBNull.Value)
				return null;
			return objRowValue;
		}

		public static object FirstValue(this DataTable dtToExtend)
		{
			object objReturnValue = null;
			if(dtToExtend.Rows.Count > 0)
			{
				if(dtToExtend.Columns.Count > 0)
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
	}
}
