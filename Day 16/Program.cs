using System;
using System.Collections.Generic;
using System.IO;

namespace Day_16
{
    class Program
    {
        static void Main()
        {
            string input = File.ReadAllText("Input.txt");
            int[] inputArray = ParseInput(input);
            int phases = 100;
            int elementsToReturn = 8;

            List<char> charList = new List<char>();
        }

        static int[] ParseInput(string input)
        {
            int[] intArray = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                intArray[i] = int.Parse(input[i].ToString());
            }

            return intArray;
        }
    }
}
