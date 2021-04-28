

using System;

namespace UExtensionLibrary.Extensions
{
    public static class Strings
    {

        /// ------------------------------------------------------------------------------------------
        ///  Name: GetFirstBetween
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Gets the substring between the first occurences of the Start and End parameters </summary>
        /// <param name="strBase">The string to modify</param>
        /// <param name="strStart">The start of the substring</param>
        /// <param name="strEnd">The end of the substring</param>
        /// <returns>System.String.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static string GetFirstBetween(this string strBase,string strStart,string strEnd)
        {
            string strReturn = "";

            string strBaseCopy = strBase;
            int intStartIndex = -1;
            int intEndIndex = -1;

            intStartIndex = strBase.IndexOf(strStart, StringComparison.Ordinal);
            if (intStartIndex == -1) return null;
            strBaseCopy = strBase.Substring(intStartIndex + strStart.Length);
            intEndIndex = strBaseCopy.IndexOf(strEnd, StringComparison.Ordinal);
            if (intEndIndex == -1) return null;

            //strReturn = strBase.Substring(intStartIndex + strStart.Length , intEndIndex );
            strReturn = strBaseCopy.Remove(intEndIndex); 
            return strReturn;
        }
        
    }
}
