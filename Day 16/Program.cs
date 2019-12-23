using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_16
{
    class Program
    {
        static void Main()
        {
            string input = File.ReadAllText("Input.txt");
            // string input = "03036732577212944063491565474664";
            int[] inputArray = ParseInput(input);
            const int phases = 100;

            // Iterate over each phase
            for (int phase = 0; phase < phases; phase++)
            {
                int[] newArray = new int[inputArray.Length];
                for (int element = 0; element < inputArray.Length; element++)
                {
                    int[] pattern = PatternVector(element + 1, input.Length);
                    newArray[element] = Math.Abs(ArrayMultiply(inputArray, pattern).Sum() % 10);
                }
                inputArray = newArray;
            }

            // Part 1 Answer
            const int elementsToReturn = 8;
            string resultString = "";
            for (int element = 0; element < elementsToReturn; element++)
            {
                resultString += inputArray[element].ToString();
            }
            Console.WriteLine("Part 1 Answer: " + resultString);


            // Part 2
            List<int> input1 = inputArray.ToList();
            List<int> input2 = new List<int>();
            for (int i = 0; i < 10000; i++) input2.AddRange(input1);
            int[] inputArray2 = input2.ToArray();

            // Iterate over each phase
            for (int phase = 0; phase < phases; phase++)
            {
                int[] newArray = new int[inputArray2.Length];
                for (int element = 0; element < inputArray2.Length; element++)
                {
                    int[] pattern = PatternVector(element + 1, inputArray2.Length);
                    newArray[element] = Math.Abs(ArrayMultiply(inputArray2, pattern).Sum() % 10);
                }
                inputArray2 = newArray;
            }

            // Part 2 Answer
            string resultString2 = "";
            int skip = Convert.ToInt32(input.Substring(0, 7));
            var result2Array = inputArray2.Skip(skip).Take(elementsToReturn);
            foreach (int element in result2Array) resultString2 += element.ToString();
            for (int element = 0; element < elementsToReturn; element++)
            {
                resultString2 += inputArray2[element].ToString();
            }
            Console.WriteLine("Part 2 Answer: " + resultString2);
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

        static int[] PatternVector(int n, int length)
        {
            List<int> pattern = new List<int>();
            for (int i = 0; i < n; i++) pattern.Add(0);
            for (int i = 0; i < n; i++) pattern.Add(1);
            for (int i = 0; i < n; i++) pattern.Add(0);
            for (int i = 0; i < n; i++) pattern.Add(-1);
            while (pattern.Count <= length)
            {
                pattern.AddRange(pattern);
            }

            IEnumerable<int> patternTrim = pattern.Skip(1).Take(length);
            int[] patternAsArray = patternTrim.ToArray();
            return patternAsArray;
        }

        static int[] ArrayMultiply(int[] a, int[] b)
        {
            int[] newArray = new int[a.Length];
            for (int i = 0; i < a.Length; i++) newArray[i] = a[i] * b[i];
            return newArray;
        }
    }
}
