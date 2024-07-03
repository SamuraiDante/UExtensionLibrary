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
        /// <summary>
        /// Gets the date of the specified day of the week relative to the input date.
        /// </summary>
        /// <param name="inputDate">The input date.</param>
        /// <param name="desiredDayOfWeek">The day of the week.</param>
        /// <returns>The date of the specified day of the week relative to the input date.</returns>
        public static DateTime GetDateOfDayOfWeek(this DateTime inputDate, DayOfWeek desiredDayOfWeek)
        {
            if (inputDate == null)
            {
                throw new ArgumentNullException(nameof(inputDate), "Input date cannot be null.");
            }

            if (!Enum.IsDefined(typeof(DayOfWeek), desiredDayOfWeek))
            {
                throw new ArgumentException("Invalid day of the week.", nameof(desiredDayOfWeek));
            }

            int daysToAdd = (int)desiredDayOfWeek - (int)inputDate.DayOfWeek;
            return inputDate.AddDays(daysToAdd);
        }

        /// <summary>
        /// Gets the date of the specified day of the week relative to the input date.
        /// </summary>
        /// <param name="inputDate">The input date.</param>
        /// <param name="desiredDayOfWeek">The day of the week.</param>
        /// <returns>The date of the specified day of the week relative to the input date.</returns>
        public static DateTime GetDateOfDayOfWeek(this DateTime inputDate, int desiredDayOfWeek)
        {
            if (inputDate == null)
            {
                throw new ArgumentNullException(nameof(inputDate), "Input date cannot be null.");
            }

            if (desiredDayOfWeek < 0 || desiredDayOfWeek > 6)
            {
                throw new ArgumentException("Invalid day of the week.", nameof(desiredDayOfWeek));
            }

            int daysToAdd = desiredDayOfWeek - (int)inputDate.DayOfWeek;
            return inputDate.AddDays(daysToAdd);
        }
    }
}
