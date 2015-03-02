using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GPS
{
	class Program
	{
		static void Main(string[] args)
		{
			string userInput = Console.ReadLine().ToLower();
			List<string> cities = new List<string>();
			HashSet<char> autocompleteSet = new HashSet<char>();

			// reading console input until end of stream (F6 or Ctrl-Z)
			string line;
			while ((line = Console.ReadLine()) != null)
			{
				cities.Add(line.ToLower());
			}

			// if a match is found, adds the next character
			// into the set
			foreach (var city in cities)
			{
				if (city.StartsWith(userInput) 
					&& city.Length > userInput.Length)
				{
					autocompleteSet.Add(
						city[userInput.Length]);
				}
			}

			if (autocompleteSet.Count == 0)
			{
				Console.Write("*");
				return;
			}

			// the point of using an enumerator is to avoid printing
			// a space symbol after the last element which will break
			// the required formatting "{0} {1} ... {n}"
			// otherwise a simple "foreach" would do
			using (var enumerator = autocompleteSet.GetEnumerator())
			{
				var flag = enumerator.MoveNext();
				char current;
				var sb = new StringBuilder();

				while (flag)
				{
					current = enumerator.Current;
					sb.Append(current);
					sb.Append((flag = enumerator.MoveNext()) ? " " : "");
				}
				Console.Write(sb);
			}
		}
	}
}
