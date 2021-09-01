// // -------------------------------------------------------------------------
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
	public static class DateTimes
	{
		public static DateTime GetDateOfDayOfWeek(this DateTime dtmInput, DayOfWeek enuDayOfWeek)
		{
			return DateTime.Now.AddDays((enuDayOfWeek - dtmInput.DayOfWeek));
		}
	}
}
