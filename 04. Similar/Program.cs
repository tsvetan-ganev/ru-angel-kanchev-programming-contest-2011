using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similar
{
	class Program
	{
		static int[,] InputMatrix(int rows, int cols)
		{
			int[,] matrix = new int[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				string[] values = Console.ReadLine().Split();
				for (int j = 0; j < cols; j++)
				{
					matrix[i, j] = int.Parse(values[j]);
				}
			}

			return matrix;
		}

		// use for testing purposes
		static void PrintMatrix(int[,] matrix)
		{
			for (int i = 0; i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= matrix.GetUpperBound(1); j++)
				{
					Console.Write("{0} ", matrix[i, j]);
				}
				Console.WriteLine();
			}
		}

		static int[] SumsOfRows(int[,] matrix)
		{
			int[] sums = new int[matrix.GetUpperBound(0) + 1];

			for (int i = 0; i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= matrix.GetUpperBound(1); j++)
				{
					sums[i] += matrix[i, j];
				}
			}

			return sums;
		}

		static int[] SumsOfCols(int[,] matrix)
		{
			int[] sums = new int[matrix.GetUpperBound(1) + 1];

			for (int j = 0; j <= matrix.GetUpperBound(1); j++)
			{
				for (int i = 0; i <= matrix.GetUpperBound(0); i++)
				{
					sums[j] += matrix[i, j];
				}
			}

			return sums;
		}

		// Finds the greatest common divisor of two numbers
		static int GCD(int a, int b)
		{
			int result = 1;
			for (int i = 1; i <= a && i <= b; i++)
			{
				if (a % i == 0 && b % i == 0)
				{
					result = i;	
				}
			}
			return result;
		}

		// Finds the greatest common divisor of an array
		static int GCD(int[] numbers)
		{
			int result = numbers[0];
			for (int i = 1; i < numbers.Length; i++)
			{
				result = GCD(result, numbers[i]);
			}
			return result;
		}

		static void Main(string[] args)
		{
			// input the 1st matrix
			string[] dimensions = Console.ReadLine().Split(' ');
			int maxRows = int.Parse(dimensions[0]);
			int maxCols = int.Parse(dimensions[1]);
			var firstMatrix = InputMatrix(maxRows, maxCols);

			// input the 2nd matrix
			dimensions = Console.ReadLine().Split(' ');
			maxRows = int.Parse(dimensions[0]);
			maxCols = int.Parse(dimensions[1]);
			var secondMatrix = InputMatrix(maxRows, maxCols);

			// find the sums of rows and cols for matrix No.1
			var sumsRowsFirst = SumsOfRows(firstMatrix);
			var sumsColsFirst = SumsOfCols(firstMatrix);

			// find the greatest common divisor for matrix No.1
			var gcdFirst = GCD(
				GCD(sumsRowsFirst),
				GCD(sumsColsFirst));

			// find the sums of rows and cols for matrix No.2
			var sumsRowsSecond = SumsOfRows(secondMatrix);
			var sumsColsSecond = SumsOfCols(secondMatrix);

			// find the greatest common divisor for matrix No.2
			var gcdSecond = GCD(
				GCD(sumsRowsSecond),
				GCD(sumsColsSecond));

			Console.WriteLine("{0} {1}", gcdFirst, gcdSecond);
			if (gcdFirst % gcdSecond == 0 || gcdSecond % gcdFirst == 0)  
				Console.WriteLine("Y");
			else
				Console.WriteLine("N");
		}
	}
}
