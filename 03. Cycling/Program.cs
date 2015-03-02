using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Cycling
{
	class Program
	{
		class Day
		{
			public int Number { get; set; }
			public int Hours { get; set; }
			public int Minutes { get; set; }
			public int Distance { get; set; }
			public double Speed 
			{
				get { return (double) Distance / TotalInMinutes; }
			}
			public int TotalInMinutes
			{
				get { return Hours * 60 + Minutes; }
			}
		}

		static string TotalTimeTravled(int minutes)
		{
			int days = 0;
			int hours = 0;
			int minsCounter = 0;

			while (minutes > 0)
			{
				if (minsCounter == 60)
				{
					hours++;
					minsCounter = 0;
				}

				if (hours == 24)
				{
					days++;
					hours = 0;
				}

				minutes--;
				minsCounter++;
			}

			return String.Format("{0} {1} {2}",
				days, hours, minsCounter);
		}

		static void Main(string[] args)
		{
			int daysCount = int.Parse(Console.ReadLine());
			List<Day> days = new List<Day>();

			for (int i = 0; i < daysCount; i++)
			{
				var inputValues = Console.ReadLine().Split();

				Day day = new Day();
				day.Number = i + 1;
				day.Hours = int.Parse(inputValues[0]);
				day.Minutes = int.Parse(inputValues[1]);
				day.Distance = int.Parse(inputValues[2]);

				days.Add(day);
			}

			var highestSpeedDay = days
				.OrderByDescending(d => d.Speed)
				.First();
			var minutes = days.Sum(d => d.TotalInMinutes);

			string finalAnswer = TotalTimeTravled(minutes);
			Console.WriteLine(finalAnswer + " " + highestSpeedDay.Number);
		}
	}
}
