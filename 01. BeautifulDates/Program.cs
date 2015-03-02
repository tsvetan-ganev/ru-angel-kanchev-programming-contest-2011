using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulDates
{
	class Program
	{
		// dictionary containing the months as key
		// and days of that month as value
		static Dictionary<int, int> monthsDays = new Dictionary<int, int>()
		{
			{1, 31}, {2, 28}, {3, 31}, {4, 30}, {5, 31}, {6, 30}, {7, 31},
   			{8, 31}, {9, 30}, {10, 31}, {11, 30}, {12, 31}
		};

		// checks if a given date is valid calendar date
		// taking leap years into consideration
		static bool IsValidDate(int day, int month, int year)
		{
			int febDays = 28 + (DateTime.IsLeapYear(year) ? 1 : 0);
			monthsDays[2] = febDays;

			if (		(year <= 9999 && year >= 1) 
					&&  (month <= 12 && month >= 1)
					&&  (day >= 1 && day <= monthsDays[month])
				)
			{
				return true;
			}

			return false;
		}

		static string Reverse(StringBuilder sb)
		{
			char temp;
			for (int i = 0; i < sb.Length / 2; i++)
			{
				temp = sb[i];
				sb[i] = sb[sb.Length - 1 - i];
				sb[sb.Length - 1 - i] = temp;
			}

			return sb.ToString();
		}

		static void Main(string[] args)
		{
			// handling string input for the start and end dates
			string startDate = Console.ReadLine();
			int startDay = Int32.Parse(startDate.Substring(0, 2));
			int startMonth = Int32.Parse(startDate.Substring(2, 2));
			int startYear = Int32.Parse(startDate.Substring(4, 4));

			string endDate = Console.ReadLine();
			int endDay = Int32.Parse(endDate.Substring(0, 2));
			int endMonth = Int32.Parse(endDate.Substring(2, 2));
			int endYear = Int32.Parse(endDate.Substring(4, 4));

			// converting the input into valid start and end dates
			var start = new DateTime(startYear, startMonth, startDay);
			var end = new DateTime(endYear, endMonth, endDay);
			var lastBeautifulDate = new DateTime(9092, 12, 31);

			// avoiding pointless calculations
			if (end > lastBeautifulDate)
			{
				end = lastBeautifulDate;
			}

			// main loop variables
			int beautifulDatesCount = 0;
			StringBuilder toBeReversed = new StringBuilder();
			string reversed;

			while (start.Date <= end.Date)
			{
				toBeReversed.Clear();
				toBeReversed.Append(start.ToString("ddMMyyyy"));
				reversed = Reverse(toBeReversed);

				int day = Int32.Parse(reversed.Substring(0, 2));
				int month = Int32.Parse(reversed.Substring(2, 2));
				int year = Int32.Parse(reversed.Substring(4, 4));

				if (IsValidDate(day, month, year))
				{
					beautifulDatesCount++;
				}

				start = start.AddDays(1);
			}

			Console.WriteLine(beautifulDatesCount);
		}
	}
}

/*
Testing all valid days from years 1 to 9999:
01010001 
31129999
*/
