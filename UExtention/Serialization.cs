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
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

using UExtensionLibrary.Extensions;
using System.Linq;
using Newtonsoft.Json;

namespace UExtensionLibrary.Extensions
{

    public static class Serialization
    {

        /// ------------------------------------------------------------------------------------------
        /// Name: Serialize
        /// ------------------------------------------------------------------------------------------
        /// <summary> Produces a usable JSON representation of the specified object. </summary>
        /// <param name="objToSerialize">The object to serialize.</param>
        /// <returns>(String)A usable JSON representation of the specified object</returns>
        /// ------------------------------------------------------------------------------------------
        public static string Serialize(object objToSerialize)
        {
            string strReturnValue = JsonConvert.SerializeObject(objToSerialize);
            return strReturnValue;
        }

        /// ------------------------------------------------------------------------------------------
        /// Name: ToJSON
        /// ------------------------------------------------------------------------------------------
        /// <summary> Produces a usable JSON representation of the specified object. </summary>
        /// <param name="objToSerialize">The object to serialize.</param>
        /// <returns>(String)A usable JSON representation of the specified object</returns>
        /// ------------------------------------------------------------------------------------------
        public static string ToJSON<T>(this T objToSerialize)
        {

            string strReturnValue = JsonConvert.SerializeObject(objToSerialize);
            return strReturnValue;
        }


        /// <summary>
        /// Converts dictionary to dictionary that uses a string as the key
        /// </summary>
        /// <typeparam name="T">Base Key type</typeparam>
        /// <typeparam name="T2">Base Value type</typeparam>
        /// <param name="dicToConvert">The distionary to convert</param>
        /// <returns></returns>
        public static Dictionary<string, T2> ToSerializableDictionary<T, T2>(this Dictionary<T, T2> dicToConvert)
        {
            Dictionary<string, T2> dicReturnDictionary = new Dictionary<string, T2>();
            List<string> lstrKeys = new List<string>();
            List<T2> lobjValues = dicToConvert.Values.ToList();
            foreach (T objItem in dicToConvert.Keys)
            {
                lstrKeys.Add(objItem.ToString());
            }
            for (int intIndex = 0; intIndex < lstrKeys.Count; intIndex += 1)
            {
                dicReturnDictionary.Add(lstrKeys[intIndex], lobjValues[intIndex]);
            }

            return dicReturnDictionary;
        }
        /// ------------------------------------------------------------------------------------------
        /// Name: Deserialize
        /// ------------------------------------------------------------------------------------------
        /// <summary> Returns an object of the specified type from a JSON string </summary>
        /// <typeparam name="T">The object type to return</typeparam>
        /// <param name="strJSON">The JSON String to use</param>
        /// <returns>An object of type T</returns>
        /// ------------------------------------------------------------------------------------------
        public static T Deserialize<T>(string strJSON)
        {

            T objReturnValue = JsonConvert.DeserializeObject<T>(strJSON);
            return objReturnValue;
        }

        /// ------------------------------------------------------------------------------------------
        /// Name: DeserializeFile
        /// ------------------------------------------------------------------------------------------
        /// <summary> Deserializes the file. </summary>
        /// <typeparam name="T">The object type to return</typeparam>
        /// <param name="strPath">The string path to the file containing the JSON string to use(Include Filename)</param>
        /// <returns>An object of type T</returns>
        /// ------------------------------------------------------------------------------------------
        public static T DeserializeFile<T>(string strPath)
        {


            string strJSON = File.ReadAllText(strPath);
            T objReturnValue = JsonConvert.DeserializeObject<T>(strJSON);
            return objReturnValue;
        }

        /// ------------------------------------------------------------------------------------------
        /// Name: CacheObject
        /// ------------------------------------------------------------------------------------------
        /// <summary> Generates a JSON string representation of the specified object, and save it to a file at the specified path. </summary>
        /// <param name="objToCache">The object to cache.</param>
        /// <param name="strPath">The location to save the file.(Include Filename)</param>
        /// ------------------------------------------------------------------------------------------
        public static void CacheObject(this object objToCache, string strPath)
        {
            string strJSON = Serialize(objToCache);
            if(Directory.Exists(Path.GetDirectoryName(strPath)) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));
            }
            File.WriteAllText(strPath, strJSON);

        }



    }

}

namespace UExtensionLibrary.Classes.Serializable
{

    public static class SerializationObjects
    {

        /// ------------------------------------------------------------------------------------------
        /// Name: JSONDatatable
        /// ------------------------------------------------------------------------------------------
        /// <summary>A middleman class to serialize/deserialize datatables to/from JSON</summary>
        /// ------------------------------------------------------------------------------------------
        public class JSONDatatable
        {
            #region Variables

            private bool m_blnIsJSONDirty = true;
            private bool m_blnIsTableDirty = true;
            private DataTable m_dtTableCache;
            private string m_strSerializeCache;

            #endregion

            [DebuggerNonUserCode]
            [DebuggerHidden]
            public JSONDatatable()
            {
                m_blnIsJSONDirty = true;
                m_blnIsTableDirty = true;
            }

            public JSONDatatable(DataTable dtToSerialize)
            {
                //Get name
                m_dtTableCache = dtToSerialize;
                m_strTableName = dtToSerialize.TableName;
                foreach (DataColumn dcColumn in dtToSerialize.Columns)
                {
                    m_dicColumns.Add(dcColumn.ColumnName, dcColumn.DataType.Name);
                }

                //Build dictionary from rows
                foreach (DataRow drBuffer in dtToSerialize.Rows)
                {
                    Dictionary<string, object> dicRow = new Dictionary<string, object>();
                    foreach (DataColumn dcBuffer in dtToSerialize.Columns)
                    {
                        dicRow.Add(dcBuffer.ColumnName, drBuffer[dcBuffer.ColumnName]);
                    }
                    m_ldicRows.Add(dicRow);
                }

                m_blnIsJSONDirty = true;
                m_blnIsTableDirty = true;
            }

            public List<Dictionary<string, object>> m_ldicRows { get; set; }
            public Dictionary<string, string> m_dicColumns { get; set; }
            public DateTime m_dtmDateSerialized { get; set; }
            public string m_strTableName { get; set; }

            /// ------------------------------------------------------------------------------------------
            /// Name: ToDataTable
            /// ------------------------------------------------------------------------------------------
            /// <summary> Builds/Returns the datatable held by the object </summary>
            /// <returns>DataTable</returns>
            /// ------------------------------------------------------------------------------------------
            public DataTable ToDataTable()
            {
                if (m_dtTableCache != null && m_blnIsTableDirty == false)
                {
                    return m_dtTableCache;
                }
                DataTable dtDeserializedDataTable = new DataTable();
                dtDeserializedDataTable.TableName = m_strTableName;
                if (m_dicColumns.Count > 0)
                {
                    //Dim dicBuffer = m_ldicRows(0)
                    foreach (string strKey in m_dicColumns.Keys)
                    {
                        Type typColumnType = typeof(string);

                        switch (m_dicColumns[strKey])
                        {
                            case "String":
                                typColumnType = typeof(string);
                                break;
                            case "Date":
                                typColumnType = typeof(DateTime);
                                break;
                            case "DateTime":
                                typColumnType = typeof(DateTime);
                                break;
                            case "Decimal":
                                typColumnType = typeof(decimal);
                                break;
                            case "Integer":
                                typColumnType = typeof(int);
                                break;
                        }
                        dtDeserializedDataTable.Columns.Add(strKey, typColumnType);
                    }
                }
                foreach (Dictionary<string, object> dicRow in m_ldicRows)
                {
                    DataRow drBuffer = dtDeserializedDataTable.Rows.Add();
                    foreach (string strKey in dicRow.Keys)
                    {
                        object val = dicRow[strKey];
                        if (val == null)
                            val = DBNull.Value;
                        drBuffer[strKey] = val;
                    }
                }
                m_dtTableCache = dtDeserializedDataTable;
                m_blnIsTableDirty = false;
                m_blnIsJSONDirty = true;
                return dtDeserializedDataTable;
            }

            public static explicit operator DataTable(JSONDatatable ToConvert)
            {
                return ToConvert.ToDataTable();
            }

            public static explicit operator string(JSONDatatable ToConvert)
            {
                return ToConvert.ToString();
            }

            /// ------------------------------------------------------------------------------------------
            /// Name: Serialize
            /// ------------------------------------------------------------------------------------------
            /// <summary> Serializes this instance. </summary>
            /// <returns>The JSON serialized string for the objects datatable</returns>
            /// ------------------------------------------------------------------------------------------
            public string Serialize()
            {
                string strReturnValue = null;
                m_dtmDateSerialized = DateTime.Now;
                strReturnValue = Serialization.Serialize(this);
                m_strSerializeCache = strReturnValue;
                m_blnIsJSONDirty = false;
                return strReturnValue;
            }

            /// ------------------------------------------------------------------------------------------
            /// Name: Cache
            /// ------------------------------------------------------------------------------------------
            /// <summary> Serializes the current datatable, and saves it as a text file at the specified path</summary>
            /// <param name="strPath">The file path location to save the file.</param>
            /// ------------------------------------------------------------------------------------------
            public void Cache(string strPath)
            {
                FileInfo fiInfo = new FileInfo(strPath);
                if (fiInfo.Directory.Exists == false)
                {
                    fiInfo.Directory.Create();
                }
                if (m_blnIsJSONDirty == false)
                {
                    File.WriteAllText(strPath, m_strSerializeCache);
                }
                else
                {
                    File.WriteAllText(strPath, Serialize());
                }
            }

            /// ------------------------------------------------------------------------------------------
            /// Name: Deserialize
            /// ------------------------------------------------------------------------------------------
            /// <summary> Deserializes a previously serialized JSONDatatable</summary>
            /// <param name="strJSON">The serialized datatable string</param>
            /// <returns>JSONDatatable</returns>
            /// ------------------------------------------------------------------------------------------
            public static JSONDatatable Deserialize(string strJSON)
            {
                return Serialization.Deserialize<JSONDatatable>(strJSON);
            }

            /// ------------------------------------------------------------------------------------------
            /// Name: ToString
            /// ------------------------------------------------------------------------------------------
            /// <summary> Returns a <see cref="System.String" /> that represents this instance. </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            /// ------------------------------------------------------------------------------------------
            public override string ToString()
            {
                if (m_blnIsJSONDirty == false)
                {
                    return m_strSerializeCache;
                }
                return Serialize();
            }

        }

    }

}