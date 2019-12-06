using System;
using System.IO;
using System.Collections.Generic;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawInput = File.ReadAllLines("Input.txt");
            List<string[]> input = processInput(rawInput);

            
        }

        static List<string[]> processInput(string[] rawInput)
        {
            List<string[]> processedInput = new List<string[]>();

            for (int i = 0; i < rawInput.Length; i++)
            {
                string[] row = new string[2];
                row = rawInput[i].Split(')');
                processedInput.Add(row);
            }

            return processedInput;
        }
    }
}
