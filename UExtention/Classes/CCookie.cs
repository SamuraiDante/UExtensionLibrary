using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace UExtensionLibrary.Classes.CCookies
{
    /// <summary>
    /// Class used to manage cookies
    /// </summary>
    public class CCookie
    {

        private Page CurrentPage;
        private HttpRequest CurrentRequest;
        public HttpResponse CurrentResponse;
        public string Key;

        public CCookie(string strKey)
        {
           CurrentPage = HttpContext.Current.Handler as Page;
            CurrentRequest = CurrentPage.Request;
            CurrentResponse = CurrentPage.Response;
            Key = strKey;
        }

        /// <summary>
        /// Sets the value of the cookie to the string
        /// </summary>
        /// <param name="Left">Cookie to set</param>
        /// <param name="Right">Value to set cookie to</param>
        /// <returns></returns>
        public  static  CCookie  operator +(CCookie Left, string Right)
        {
            HttpCookie ckeBuffer = Left.CurrentRequest.Cookies[Left.Key] ?? new HttpCookie(Left.Key);
            ckeBuffer.Value = Right;
            ckeBuffer.Expires = DateTime.Now.AddDays(30);
            Left.CurrentResponse.Cookies.Add(ckeBuffer);

            return Left;
        }
        /// <summary>
        /// Sets the string to the cookies value
        /// </summary>
        /// <param name="Left">String to set</param>
        /// <param name="Right">Cookie to get value from</param>
        /// <returns></returns>
        public static string operator +(string Left, CCookie Right)
        {
            var httpCookie = Right.CurrentRequest.Cookies[Right.Key];
            string strBuffer = null;
            if (httpCookie != null)
            {
               strBuffer = httpCookie.Value;
            }


            return strBuffer;
        }
        /// <summary>
        /// Converts cookie to its string value
        /// </summary>
        /// <param name="ckeToConvert"></param>
        public static implicit operator string(CCookie ckeToConvert)
        {
            string strReturnValue = "";
            strReturnValue += ckeToConvert;
            return strReturnValue;
        }

       

    }
}
