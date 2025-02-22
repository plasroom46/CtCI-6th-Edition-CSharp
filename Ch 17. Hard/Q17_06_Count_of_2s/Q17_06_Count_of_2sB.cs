﻿using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_06_Count_of_2s
{
	// 改進後的方案
    public class Q17_06_Count_of_2sB : Question
    {
		public static int Count2sInRangeAtDigit(int number, int d)
		{
			int powerOf10 = (int)Math.Pow(10, d);
			int nextPowerOf10 = powerOf10 * 10;
			int right = number % powerOf10;

			int roundDown = number - number % nextPowerOf10;
			int roundUp = roundDown + nextPowerOf10;

			int digit = (number / powerOf10) % 10;
			if (digit < 2)
			{ // if the digit in spot digit is 
				return roundDown / 10;
			}
			else if (digit == 2)
			{
				return roundDown / 10 + right + 1;
			}
			else
			{
				return roundUp / 10;
			}
		}

		public static int Count2sInRange(int number)
		{
			int count = 0;
			int len = number.ToString().Length;
			for (int digit = 0; digit < len; digit++)
			{
				count += Count2sInRangeAtDigit(number, digit);
			}
			return count;
		}

		public static int count2sR(int n)
		{
			/* Alternate, messier, solution */

			// Example: n = 513

			// Base case
			if (n == 0)
			{
				return 0;
			}

			// Split apart 513 into 5 * 100 + 13.
			// [Power = 100; First = 5; Remainder = 13]
			int power = 1;
			while (10 * power < n)
			{
				power *= 10;
			}
			int first = n / power;
			int remainder = n % power;

			// Counts 2s from first digit
			int nTwosFirst = 0;
			if (first > 2)
			{
				nTwosFirst += power;
			}
			else if (first == 2)
			{
				nTwosFirst += remainder + 1;
			}

			// Count 2s from all other digits
			int nTwosOther = first * count2sR(power - 1) + count2sR(remainder);

			return nTwosFirst + nTwosOther;
		}

		public override void Run()
        {
			for (int i = 0; i < 10000; i++)
			{
				int v1 = count2sR(i);
				int v2 = Count2sInRange(i);
				Console.WriteLine("Between 0 and " + i + ": " + v1 + " " + v2);
			}
		}
    }
}
