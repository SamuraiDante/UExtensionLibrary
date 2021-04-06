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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms.VisualStyles;
using UExtensionLibrary.Enumerables;

namespace UExtensionLibrary.Reflection
{

    public static class Reflection
    {

        /// ------------------------------------------------------------------------------------------
        /// Name: GetPropertyValue
        /// ------------------------------------------------------------------------------------------
        /// <summary> Gets the specified properties value. </summary>
        /// <param name="objObject">The containing object.</param>
        /// <param name="strPropertyName">The name of the property.</param>
        /// <returns>System.Object.</returns>
        /// ------------------------------------------------------------------------------------------
        public static object GetPropertyValue(this object objObject, string strPropertyName)
        {
            //Get the property type
            Type objType = objObject.GetType();
            object objValue = null;
            PropertyInfo pInfo = default(PropertyInfo);
            string strPropertyValue = null;

            //Attempt to get the properties info
            try
            {
                pInfo = objType.GetProperty(strPropertyName);
            }
            catch (Exception ex)
            {
                //If unable to get the info, return a string stating that as the value
                strPropertyValue = "Unable to determine value";
                return strPropertyValue;
            }

            IEnumerable ienuValue = default(IEnumerable);

            //Ignore setter, as they contain no value
            if (!strPropertyName.Contains("set_") && pInfo != null)
            {
                //Remove the gets from getters, so it is formatted correctly for GetValue
                strPropertyName = strPropertyName.Replace("get_", "");
                try
                {
                    //Get the value
                    objValue = pInfo.GetValue(objObject, null);

                    //If the value is enummerable, build a single string from the enummerables values
                    ienuValue = objValue as IEnumerable;

                    //Value will be nothing if not enumberable
                    if ((objValue) is string || (ienuValue == null))
                    {
                        strPropertyValue = objValue.ToString();
                    }
                    else
                    {
                        IEnumerable itemLoopVariables = ienuValue as object[] ?? ienuValue.Cast<object>().ToArray();
                        if (!itemLoopVariables.IsNullOrEmpty())
                        {
                            strPropertyValue += '\n';
                            foreach (object Item_loopVariable in itemLoopVariables)
                            {
                                object Item = Item_loopVariable;
                                strPropertyValue += "\t\t" + Item + '\t';
                            }
                        }
                        else
                        {
                            //If the enummerable has no values, send that information back as the value
                            strPropertyValue = "Empty";
                        }
                    }
                }
                catch (Exception ex)
                {
                    //If anything breaks, give up and move on
                    strPropertyValue = "Unable to determine value";
                }

            }

            return strPropertyValue;
        }

        /// ------------------------------------------------------------------------------------------
        /// Name: GetFieldValue
        /// ------------------------------------------------------------------------------------------
        /// <summary> Gets the specified fields value. </summary>
        /// <param name="objObject">The containing object.</param>
        /// <param name="strFieldName">The name of the field.</param>
        /// <returns>System.Object.</returns>
        /// ------------------------------------------------------------------------------------------
        public static object GetFieldValue(object objObject, string strFieldName)
        {
            Type objType = objObject.GetType();
            object objValue = null;

            FieldInfo fInfo = objType.GetField(strFieldName);
            IEnumerable ienuValue = default(IEnumerable);
            object strFieldValue = null;
            if (fInfo != null)
            {
                try
                {
                    //Get value as object
                    objValue = fInfo.GetValue(objObject);

                    //check if the value is an enumerable list
                    ienuValue = objValue as IEnumerable;

                    //Value will be nothing if not enumberable
                    if ((objValue) is string || ienuValue == null)
                    {
                        strFieldValue = objValue;
                    }
                    else
                    {
                        IEnumerable itemLoopVariables = ienuValue as object[] ?? ienuValue.Cast<object>().ToArray();
                        if (!itemLoopVariables.IsNullOrEmpty())
                        {
                            foreach (object Item_loopVariable in itemLoopVariables)
                            {
                                object Item = Item_loopVariable;
                                strFieldValue += "\t\t" + Item + '\t';
                            }
                        }
                        else
                        {
                            strFieldValue = "Empty";
                        }
                    }
                }
                catch (Exception ex)
                {
                    strFieldValue = "Unable to determine value";
                }

            }

            return strFieldValue;
        }



    }

}