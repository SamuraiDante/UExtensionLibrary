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
using System.Linq;

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

        /// <summary>
        /// Appends dictionary of the same types
        /// </summary>
        /// <typeparam name="T">Key type</typeparam>
        /// <typeparam name="T2">Value type</typeparam>
        /// <param name="dicCurrent">Dictionary to append <paramref name="dicToAppend"/> to.</param>
        /// <param name="dicToAppend">Dictionary to append to <paramref name="dicCurrent"/></param>
        /// <param name="blnOverwriteExisting">If true, when <paramref name="dicToAppend"/> has keys that <paramref name="dicCurrent"/> already has, the value will be replaced. If false, they will be skipped</param>
        public static void Append<T,T2>(this Dictionary<T,T2> dicCurrent, Dictionary<T, T2> dicToAppend, bool blnOverwriteExisting = false)
        {              
            foreach (T Key in dicToAppend.Keys)
            {
                if (dicCurrent.ContainsKey(Key) == false) dicCurrent.Add(Key, dicToAppend[Key]);
                else
                {
                    if (blnOverwriteExisting == true) dicCurrent[Key] = dicToAppend[Key];
                }
            }
        }
        /// <summary>
        /// Returns if an object is a dictionary
        /// </summary>
        /// <returns>System.Bool</returns>
        //public static bool IsDictionary<T>(this T objToCheck)
        //{
        //    bool blnReturnValue = false;
        //    Type t = objToCheck.GetType();
        //    blnReturnValue = t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        //    return blnReturnValue;
        //}

        //public static Dictionary<string, object> AssumeDictionary(this object objValue)
        //{
        //    Dictionary<string, object> dicReturnDictionary = new Dictionary<string, object>();
        //    if (objValue.IsDictionary())
        //    {
        //        Type DictionaryType = objValue.GetType();
        //        Type T1 = DictionaryType.GenericTypeArguments[0];
        //        Type T2 = DictionaryType.GenericTypeArguments[1];
        //        (Dictionary<T1.GetType(), T2>) Value;
        //    }
        //    List<string> lstrKeys = new List<string>();
        //    List<T2> lobjValues = dicValue.Values.ToList();
        //    foreach (T objItem in dicValue.Keys)
        //    {
        //        lstrKeys.Add(objItem.ToString());
        //    }
        //    for (int intIndex = 0; intIndex < lstrKeys.Count; intIndex += 1)
        //    {
        //        dicReturnDictionary.Add(lstrKeys[intIndex], lobjValues[intIndex]);
        //    }

        //    return dicReturnDictionary;
        //}



    }

}