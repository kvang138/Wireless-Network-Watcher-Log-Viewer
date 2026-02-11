/**
 * 
 *  The class used for date/time calculation and for generating date/time friendly string.
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.SqlServer.Management.RegisteredServers;

namespace WirelessNetWatcherLogViewer
{
    // The date/time calculator wrapper class.
    public class DateTimeCalculator
    {
        // The function prototype for the calculate method.
        public Func<string, string> calculate { get; }
        // The function prototype for the isMatch method.
        public Func<string, bool> isMatch { get; }

        public DateTimeCalculator(Func<string, string> calculate, Func<string, bool> isMatch)
        {
            this.calculate = calculate;
            this.isMatch = isMatch;
        }
    }

    public class DateTimeCalculators
    {
        private Dictionary<string, DateTimeCalculator> calculators = new Dictionary<string, DateTimeCalculator>();

        public DateTimeCalculators()
        {
            // Calculate the number of seconds.
            calculators["seconds"] = new DateTimeCalculator(
                calculate: timeString =>
                {
                    int multiplier = -1;

                    if (!Regex.IsMatch(timeString, "last|previous", RegexOptions.IgnoreCase))
                        multiplier = 1;

                    return DateTime.Now.AddSeconds(Int64.Parse(Regex.Match(timeString, "\\d+").Groups[0].ToString()) * multiplier).ToString();
                },
                isMatch: timeString =>
                {
                    return Regex.IsMatch(timeString, "(?:secs?|seconds?|(?: |\\d+)s)$", RegexOptions.IgnoreCase);
                }
            );

            // Calculate the number of minutes.
            calculators["minute"] = new DateTimeCalculator(
                calculate: timeString =>
                {
                    int multiplier = -1;

                    if (!Regex.IsMatch(timeString, "last|previous", RegexOptions.IgnoreCase))
                        multiplier = 1;

                    return DateTime.Now.AddMinutes(Int64.Parse(Regex.Match(timeString, "\\d+").Groups[0].ToString()) * multiplier).ToString();
                },
                isMatch: timeString =>
                {
                    return Regex.IsMatch(timeString, "(?:m[^o]|mins?|minutes?)$", RegexOptions.IgnoreCase);
                }
            );

            // Calculate the number of hours.
            calculators["hour"] = new DateTimeCalculator(
                calculate: timeString =>
                {
                    int multiplier = -1;

                    if (!Regex.IsMatch(timeString, "last|previous", RegexOptions.IgnoreCase))
                        multiplier = 1;

                    return DateTime.Now.AddHours(Int64.Parse(Regex.Match(timeString, "\\d+").Groups[0].ToString()) * multiplier).ToString();
                },
                isMatch: timeString =>
                {
                    return Regex.IsMatch(timeString, "(?:hours?|hrs?|(?: |\\d+)h)$", RegexOptions.IgnoreCase);
                }
            );

            // Calculate the number of days.
            calculators["day"] = new DateTimeCalculator(
                calculate: timeString =>
                {
                    int multiplier = -1;

                    if (!Regex.IsMatch(timeString, "last|previous", RegexOptions.IgnoreCase))
                        multiplier = 1;

                    return DateTime.Now.AddDays(Int64.Parse(Regex.Match(timeString, "\\d+").Groups[0].ToString()) * multiplier).ToString();
                },
                isMatch: timeString =>
                {
                    return Regex.IsMatch(timeString, "(?:ds?|days?)$", RegexOptions.IgnoreCase);
                }
            );

            // Calculate the number of weeks.
            calculators["week"] = new DateTimeCalculator(
                calculate: timeString =>
                {
                    int multiplier = -1;

                    if (!Regex.IsMatch(timeString, "last|previous", RegexOptions.IgnoreCase))
                        multiplier = 1;

                    return DateTime.Now.AddDays(Int64.Parse(Regex.Match(timeString, "\\d+").Groups[0].ToString()) * multiplier * 7).ToString();
                },
                isMatch: timeString =>
                {
                    return Regex.IsMatch(timeString, "(?:wks?|weeks?)$", RegexOptions.IgnoreCase);
                }
            );

            // Calculate the number of months.
            calculators["month"] = new DateTimeCalculator(
                calculate: timeString =>
                {
                    int multiplier = -1;

                    if (!Regex.IsMatch(timeString, "last|previous", RegexOptions.IgnoreCase))
                        multiplier = 1;

                    return DateTime.Now.AddMonths(int.Parse(Regex.Match(timeString, "\\d+").Groups[0].ToString()) * multiplier).ToString();
                },
                isMatch: timeString =>
                {
                    return Regex.IsMatch(timeString, "(?:mos?|months?)$", RegexOptions.IgnoreCase);
                }
            );

            // Calculate the number of years.
            calculators["year"] = new DateTimeCalculator(
                calculate: timeString =>
                {
                    int multiplier = -1;

                    if (!Regex.IsMatch(timeString, "last|previous", RegexOptions.IgnoreCase))
                        multiplier = 1;

                    return DateTime.Now.AddYears(int.Parse(Regex.Match(timeString, "\\d+").Groups[0].ToString()) * multiplier).ToString();
                },
                isMatch: timeString =>
                {
                    return Regex.IsMatch(timeString, "(?:yrs?|years?)$", RegexOptions.IgnoreCase);
                }
            );
        }

        /***
         * 
         * 
         * Calculate the date/time based on time string such as 18 minutes ago.
         * 
         */
        public string calculateDateTime(string timeString)
        {
            // Dynamically use the appropriate time unit calculate method 
            foreach (KeyValuePair<string, DateTimeCalculator> calculator in calculators)
            {
                if (calculator.Value.isMatch(timeString))
                    return calculator.Value.calculate(timeString);
            }

            // Just if return the current time, if no appropriate method was found
            return DateTime.Now.ToString();
        }

        /***
         * 
         * Generate a friendly string such as 18 minutes ago based on the start and end date/time.
         * 
         */
        private string generateFriendlyTimeString(DateTime startDateTime, DateTime endDateTime)
        {
            List<string> dateTimeParts = new List<string>();
            string friendlyTimeString = "";

            TimeSpan timeSpan = endDateTime - startDateTime;

            // Calculate the number of days all the way to the number of years based the two date/time strings.
            long totalDays = (long)(timeSpan.TotalDays);
            long years = totalDays / 365;
            long daysAfterYears = totalDays % 365;
            int months = (int)(daysAfterYears / 30.4375);
            long daysAfterMonth = (long)Math.Round(daysAfterYears % 30.4375);
            int weeks = (int)(daysAfterMonth / 7);
            int days = (int)(daysAfterMonth % 7);

            // If it is a year or more.
            if (years > 0)
                dateTimeParts.Add($"{years} year{(years > 1 ? "s" : "")}");

            // If it is a month or more.
            if (months > 0)
                dateTimeParts.Add($"{months} month{(months > 1 ? "s" : "")}");

            // If it is a week or more.
            if (weeks > 0)
                dateTimeParts.Add($"{weeks} week{(weeks > 1 ? "s" : "")}");

            // If it is a day or more.
            if (days > 0)
                dateTimeParts.Add($"{days} day{(days > 1 ? "s" : "")}");

            // If it is a hour or more.
            if (timeSpan.Hours > 0)
                dateTimeParts.Add($"{timeSpan.Hours} Hour{(timeSpan.Hours > 1 ? "s" : "")}");

            // If it is a minute or more.
            if (timeSpan.Minutes > 0)
                dateTimeParts.Add($"{timeSpan.Minutes} Minute{(timeSpan.Minutes > 1 ? "s" : "")}");

            // If it is a second or more.
            if (timeSpan.Seconds > 0)
                dateTimeParts.Add($"{timeSpan.Seconds} Second{(timeSpan.Seconds > 1 ? "s" : "")}");

            // If it is a millisecond or more.
            if (timeSpan.Milliseconds > 0)
                dateTimeParts.Add($"{timeSpan.Milliseconds} Millisecond{(timeSpan.Milliseconds > 1 ? "s" : "")}");

            // Combine the date/time parts together into a friendly time string.
            friendlyTimeString = string.Join(" ", dateTimeParts);

            // Append the , and with last time unit to make more natural.
            if (dateTimeParts.Count > 1)
                friendlyTimeString = Regex.Replace(friendlyTimeString, "(\\d+ [A-z]+)$", "and $1", RegexOptions.IgnoreCase);
            
            return friendlyTimeString;
        }

        /// Will implement it later.
        public string toFriendlyTimeStringPrecise(string timeString1, string timeString2)
        {
            throw new NotImplementedException();
        }

        // Convert to start and end time string into a single friendly time string
        public string toFriendlyTimeString(string timeString1, string timeString2)
        {
            DateTime startDateTime;
            DateTime endStartDateTime;
            DateTime temp;

            string pastPresentFuture = "ago";
            List<string> dateTimeParts = new List<string>();
            string friendlyTimeString = "";
            DateTime now = DateTime.Now;

            // Make the time strings are valid time strings.
            try
            {
                startDateTime = DateTime.Parse(timeString1);
                endStartDateTime = DateTime.Parse(timeString2);

                // If the start and end time are the same as the current time now, then just return "Now"
                if (startDateTime == now && endStartDateTime == now)
                    return "Now";

                // Swap the two date if the start date/time is after the end date/time.
                if (startDateTime > endStartDateTime)
                {
                    temp = endStartDateTime;
                    endStartDateTime = startDateTime;
                    startDateTime = temp;
                }

                // If the start date/time is before the current day/time now, then it is in the future.
                if (startDateTime > now)
                    pastPresentFuture = "in the future";

                // If the start date/time was in the past or the present.
                if (startDateTime <= now)
                    friendlyTimeString = $@"{generateFriendlyTimeString(startDateTime, endStartDateTime <= now ? endStartDateTime : now)} {pastPresentFuture}.";

                // Include the future part if the time span spans from the past or present into the future.
                if (endStartDateTime > now)
                    friendlyTimeString += $"{(friendlyTimeString != "" ? "\r\n, and" : "")} {generateFriendlyTimeString(now, endStartDateTime)} in the future.";
            }
            catch (Exception e)
            {
                return "Invalid time string(s).";
            }

            // Return the generate friendly time string.
            return friendlyTimeString;
        }
    }
}