using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_7
{
    class Program
    {
        static void Main()
        {
            string inputString = "3,8,1001,8,10,8,105,1,0,0,21,34,55,68,93,106,187,268,349,430,99999,3,9,102,5,9,9,1001,9,2,9,4,9,99,3,9,1001,9,5,9,102,2,9,9,101,2,9,9,102,2,9,9,4,9,99,3,9,101,2,9,9,102,4,9,9,4,9,99,3,9,101,4,9,9,102,3,9,9,1001,9,2,9,102,4,9,9,1001,9,2,9,4,9,99,3,9,101,2,9,9,1002,9,5,9,4,9,99,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,99,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,99,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,99";
            List<int> candidates = new List<int>();
            int[][] possiblePhases = new int[Factorial(5)][];
            // for (int i = 0; i < possiblePhases.Length; i++)
            // {
            //     for (int a = 0; a < 5; a++)
            //     {
            //         List<int> phaseOptions = new List<int> { 0, 1, 2, 3, 4 };
            //         int[] combination = new int[5];
            //         combination[0] = phaseOptions[0];
            //         phaseOptions.Remove(combination[0]);
            //         for (int b = 0; b < 4; b++)
            //         {
            //             combination[1] = phaseOptions[0];
            //             phaseOptions.Remove(combination[1]);
            //             for (int c = 0; c < 3; c++)
            //             {
            //                 combination[2] = phaseOptions[0];
            //                 phaseOptions.Remove(combination[2]);
            //                 for (int d = 0; d < 2; d++)
            //                 {
            //                     combination[3] = phaseOptions[d];
            //                     // phaseOptions.Remove(combination[3]);
            //                     combination[4] = phaseOptions[(d + 1) % 2];

            //                     possiblePhases[i] = combination;
            //                 }
            //             }
            //         }
            //     }
            // }

            int[] x = { 0, 1, 2, 3, 4 };

            List<int[]> y = heapPermutation(x, 5, 5);


            IntcodeComputer A = new IntcodeComputer(inputString);
            IntcodeComputer B = new IntcodeComputer(inputString);
            IntcodeComputer C = new IntcodeComputer(inputString);
            IntcodeComputer D = new IntcodeComputer(inputString);
            IntcodeComputer E = new IntcodeComputer(inputString);
            int outA = A.Calculate(2, 0);
            int outB = B.Calculate(0, outA);
            int outC = C.Calculate(0, outB);
            int outD = D.Calculate(0, outC);
            int outE = E.Calculate(0, outD);
            candidates.Add(outE);

            int result = candidates.Max();
            Console.WriteLine(result);
        }

        static int Factorial(int integer)
        {
            int fact = 1;
            for (int i = 1; i <= integer; i++)
            {
                fact = fact * i;
            }
            return fact;
        }
        static void printArr(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }
        //Generating permutation using Heap Algorithm 
        static List<int[]> heapPermutation(int[] a, int size, int n)
        {

            List<int[]> possiblePhases = new List<int[]>();
            // if size becomes 1 then prints the obtained 
            // permutation 
            if (size == 1)
                possiblePhases.Add(a);
            // while (size != 1)
            // {
            for (int i = 0; i < size; i++)
            {
                heapPermutation(a, size - 1, n);

                // if size is odd, swap first and last 
                // element 
                if (size % 2 == 1)
                {
                    int temp = a[0];
                    a[0] = a[size - 1];
                    a[size - 1] = temp;
                }

                // If size is even, swap ith and last 
                // element 
                else
                {
                    int temp = a[i];
                    a[i] = a[size - 1];
                    a[size - 1] = temp;
                }
            }
            // }
            return possiblePhases;
        }
    }
}
