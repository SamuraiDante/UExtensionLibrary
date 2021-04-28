// // -------------------------------------------------------------------------
// // File: Enumerables.cs
// // Author: Hughes, Donivan(hughes.dh.1)
// // Abstract: TODO: Add abstract
// //
// // Created: 07/12/2016 11:11 AM
// // Last Updated: 07/12/2016 11:11 AM
// // -------------------------------------------------------------------------
// 
// // -------------------------------------------------------------------------
// // Imports
// // -------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace UExtensionLibrary.Extensions
{

    public static class Numerics
    {

        /// ------------------------------------------------------------------------------------------
        ///  Name: Val
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Gets the numeric value from the string </summary>
        /// <param name="strExpression">The string expression.</param>
        /// <returns>System.Double</returns>
        /// <remarks>Acts as VB Val, but gets first numeric value from string regardless or leading or trailing characters</remarks>
        ///  ------------------------------------------------------------------------------------------
        public static double Val(string strExpression)
        {
            double dblReturn = 0;
            if(strExpression != null)dblReturn = Microsoft.VisualBasic.Conversion.Val(strExpression.Substring(Regex.Match(strExpression, @"\d|\.\d").Index));

            return dblReturn;
        }
        /// ------------------------------------------------------------------------------------------
        ///  Name: ToDouble
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Gets the numeric value from the string </summary>
        /// <param name="strExpression">The string expression.</param>
        /// <returns>System.Double</returns>
        /// <remarks>Acts as VB Val, but gets first numeric value from string regardless or leading or trailing characters.</remarks>
        ///  ------------------------------------------------------------------------------------------
        public static double ToDouble(this string strExpression)
        {
            double dblReturn = 0;
            if(strExpression != null)dblReturn = Microsoft.VisualBasic.Conversion.Val(strExpression.Substring(Regex.Match(strExpression, @"\d|\.\d").Index));

            return dblReturn;
        }
    }

}