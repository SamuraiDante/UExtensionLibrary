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
		public static string GetFirstBetween(this string strBase, string strStart, string strEnd)
		{
			string strReturn = "";

			string strBaseCopy = strBase;
			int intStartIndex = -1;
			int intEndIndex = -1;

			intStartIndex = strBase.IndexOf(strStart, StringComparison.Ordinal);
			if(intStartIndex == -1)
				return null;
			strBaseCopy = strBase.Substring(intStartIndex + strStart.Length);
			intEndIndex = strBaseCopy.IndexOf(strEnd, StringComparison.Ordinal);
			if(intEndIndex == -1)
				return null;

			//strReturn = strBase.Substring(intStartIndex + strStart.Length , intEndIndex );
			strReturn = strBaseCopy.Remove(intEndIndex);
			return strReturn;
		}

		public static int CharacterInstanceCount(this string strBase, char chrToCount)
		{
			int intCount = 0;
			foreach(char Character in strBase)
			{
				if(Character == chrToCount)
					intCount += 1;
			}
			return intCount;
		}

		public static string[] TrimSplit(this string strBase, char[] strSeparator)
		{
			string[] astrReturn = strBase.Split(strSeparator);
			for(int intIndex = 0; intIndex < astrReturn.Length; intIndex += 1)
			{
				astrReturn[intIndex] = astrReturn[intIndex].Trim();
			}
			return astrReturn;
		}

		public static string[] TrimSplit(this string strBase, string strSeparator)
		{
			return TrimSplit(strBase, strSeparator.ToCharArray());
		}

		
		//public static string PadEquallyWith(this string Base, char Padding,int Length)
		//{
		//	string ReturnValue = Base;
			
		//	int LengthNeeded = Length - Base.Length;
		//	if (LengthNeeded > 0)
		//	{
		//		bool Even = !(LengthNeeded % 2 == 0);

		//		if (Even)
		//		{
		//			ReturnValue = ReturnValue.PadLeft((LengthNeeded / 2) + ReturnValue.Length, Padding);
		//			ReturnValue = ReturnValue.PadRight(Length, Padding);
		//		}
		//		else
		//		{
		//			ReturnValue = ReturnValue.PadLeft((LengthNeeded / 2) + ReturnValue.Length, Padding);
		//			ReturnValue = ReturnValue.PadRight(Length, Padding);
		//		}
		//	}
		//	return ReturnValue;


        //}
		

      
    }
}
