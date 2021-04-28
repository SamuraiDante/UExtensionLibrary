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

namespace UExtensionLibrary.Extensions
{

    public static class Enumerables
    {
        /// ------------------------------------------------------------------------------------------
        ///  Name: Reverse
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Reverses the ILists content order </summary>
        /// <param name="IListToExtend">The IList to reverse</param>
        ///  ------------------------------------------------------------------------------------------
        public static void Reverse(this IList IListToExtend)
        {
            object[] lstReturn = new object[IListToExtend.Count];
            IListToExtend.CopyTo(lstReturn, 0);
            Array.Reverse(lstReturn);
            IListToExtend.Clear();                  
            for (int i = 0; i < lstReturn.Length; i+= 1)
            {
                IListToExtend.Add(lstReturn[i]);
            }
        }


        /// ------------------------------------------------------------------------------------------
        ///  Name: IsNullOrEmpty
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Determines whether this IEnumerable is nothing and has no members . </summary>
        /// <returns><c>true</c> if [is null or empty] returns true; otherwise, <c>false</c>.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static bool IsNullOrEmpty(this IEnumerable ienuToExtend)
        {
            bool blnReturnValue = true;

            if (ienuToExtend != null)
            {
                foreach (object Item in ienuToExtend)
                {

                    blnReturnValue = false;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            return blnReturnValue;

        }


        /// ------------------------------------------------------------------------------------------
        ///  Name: GetDictionaryFromEnum
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Returns a dictionary containing enum values as keys, and text names as values or the specified type</summary>
        /// <typeparam name="T">Enum to examine</typeparam>
        /// <returns>Dictionary&lt;System.Int32, System.String&gt;.</returns>
        ///  ------------------------------------------------------------------------------------------
        public static Dictionary<int,string> GetDictionaryFromEnum<T>()
        {
            Dictionary<int, string> dicReturnValue = new Dictionary<int,string>();
            Type t = typeof(T);
            foreach(int intValue in Enum.GetValues(t))
            {
                dicReturnValue.Add(intValue, Enum.GetName(t, intValue));
            }
            return dicReturnValue;

        }

    }

}