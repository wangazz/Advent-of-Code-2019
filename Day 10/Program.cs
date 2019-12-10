﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day_10
{
    class Program
    {
        static void Main()
        {
            // Process inputs
            string[] inputLines = File.ReadAllLines("input.txt");
            int[][] inputArray = new int[inputLines.Length][];
            int asteroidIndex = 1;
            for (int i = 0; i < inputLines.Length; i++)
            {
                string str = inputLines[i];
                int[] line = new int[str.Length];
                for (int j = 0; j < str.Length; j++)
                {
                    line[j] = str[j] == '.' ? 0 : asteroidIndex;
                    if (line[j] == asteroidIndex) asteroidIndex++;
                }
                inputArray[i] = line;
            }
            asteroidIndex--;

        
            // Part 1 Solution
            // Calculate absolute positions
            int[][] positionArray = new int[asteroidIndex][];
            for (int asteroid = 1; asteroid <= asteroidIndex; asteroid++)
            {
                int[] thisXY = new int[2];
                for (int x = 0; x < inputArray.Length; x++)
                {
                    if (inputArray[x].Contains(asteroid))
                    {
                        thisXY[0] = Array.IndexOf(inputArray[x], asteroid);
                        thisXY[1] = x;
                        positionArray[asteroid - 1] = thisXY;
                    }
                }
            }

            // Calculate relative positions and count distinct values
            int[] detectableArray = new int[asteroidIndex];
            for (int i = 0; i < positionArray.Length; i++)
            {
                int[] thisAsteroid = positionArray[i];
                List<double> relativeXY0 = new List<double>();
                List<double> relativeXY1 = new List<double>();
                List<double> relativeXY2 = new List<double>();
                for (int j = 0; j < positionArray.Length; j++)
                {
                    int[] thatAsteroid = positionArray[j];
                    int diffX = thatAsteroid[0] - thisAsteroid[0];
                    int diffY = thatAsteroid[1] - thisAsteroid[1];
                    
                    if (diffY == 0) // same row
                    {
                        double ratio = diffX == 0 ? 0 : diffX / Math.Abs(diffX);
                        if (ratio != 0 ) relativeXY0.Add(ratio);
                    }
                    else if (diffY < 0) // upper subspace
                    {
                        double ratio = (double) diffX / diffY;
                        relativeXY1.Add(ratio);
                    }
                    else if (diffY > 0) // lower subspace
                    {
                        double ratio = (double) diffX / diffY;
                        relativeXY2.Add(ratio);
                    }
                }
                int detectableTotal = relativeXY0.Distinct().Count() + relativeXY1.Distinct().Count() + relativeXY2.Distinct().Count();
                detectableArray[i] = detectableTotal;
            }

            int result = detectableArray.Max();
            Console.WriteLine(result);


            // Part 2 Solution


        }

    }
}
