using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace UExtensionLibrary.Methods
{
    public static partial class Conversion
    {
        public static T2 MemberwiseConvert<T1, T2>(T1 Source) where T2 : new()
        {
            T2 ReturnValue = new T2();
            Type SourceType = typeof(T1);
            PropertyInfo[] Members = SourceType.GetProperties().ToArray();
            Type DestinationType = typeof(T2);
            foreach (PropertyInfo Member in Members)
            {
                object Value = Member.GetValue(Source);

                DestinationType.GetProperty(Member.Name).SetValue(ReturnValue, Value);
            }
            return ReturnValue;
        }

        public static void MemberwiseCopyTo<T>(T Source,object Destination ) 
        {
            
            Type SourceType = typeof(T);
            PropertyInfo[] Members = SourceType.GetProperties().ToArray();
            foreach (PropertyInfo Member in Members)
            {
                object Value = Member.GetValue(Source);

                Member.SetValue(Destination, Value);
            }
        }

        public static T MemberwiseDynamicCast<T>(dynamic Source) where T : new()
        {
            T ReturnValue = new T();
            Type DestinationType = typeof(T);
            PropertyInfo[] Properties = DestinationType.GetProperties().ToArray();
            foreach (PropertyInfo Property in Properties)
            {
                foreach (var Member in Source)
                {
                    if (Member.Key == Property.Name)
                    {
                        Property.SetValue(ReturnValue, Member.Value);
                    }
                }
            }
            return ReturnValue;
        }


    }

}

namespace UExtensionLibrary.Extensions
{
    public static partial class Convertion
    {
        #region Short

        public static byte[] ToByteArray(this short[] Source)
        {
            byte[] ReturnValue = new byte[Source.Length * 2];
            for (int i = 0; i < Source.Length; i++)
            {
                byte[] Bytes = BitConverter.GetBytes(Source[i]);
                ReturnValue[i * 2] = Bytes[0];
                ReturnValue[i * 2 + 1] = Bytes[1];
            }

            return ReturnValue;
        }
        #endregion Short
        #region String
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
            if (strExpression != null) dblReturn = Microsoft.VisualBasic.Conversion.Val(strExpression.Substring(Regex.Match(strExpression, @"\d|\.\d").Index));

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
            if (strExpression != null) dblReturn = Microsoft.VisualBasic.Conversion.Val(strExpression.Substring(Regex.Match(strExpression, @"\d|\.\d").Index));

            return dblReturn;
        }

        public static byte[] ToByteArray(this string strBase)
        {
            byte[] abyReturn = new byte[strBase.Length];
            for (int intIndex = 0; intIndex < strBase.Length; intIndex += 1)
            {
                abyReturn[intIndex] = (byte)strBase[intIndex];
            }
            return abyReturn;
        }

        public static void FromCharArray(this string strBase, char[] achrSource, bool blnAppend = false)
        {
            if (!blnAppend)
                strBase = "";
            strBase = "";
            foreach (char Character in achrSource)
            {

                strBase += Character;
            }
        }

        #endregion String

        #region Char
        public static string _ToString(this char[] achrBase)
        {
            if (achrBase == null)
                return null;
            string ReturnValue = string.Empty;
            foreach (char Character in achrBase)
            {
                ReturnValue += Character;
            }
            return ReturnValue;
        }
        #endregion Char


    }

}