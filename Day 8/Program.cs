using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day_8
{
    class Program
    {
        static void Main()
        {
            string inputString = File.ReadAllText("input.txt");
            int height = 6;
            int width = 25;

            // Part One

            List<string> layers = new List<string>();

            for (int i = 0; i < inputString.Length; i += height * width)
            {
                string sub;
                sub = inputString.Substring(i, height * width);
                layers.Add(sub);
            }

            int[] zeroesArray = new int[layers.Count];
            int[] onesArray = new int[layers.Count];
            int[] twosArray = new int[layers.Count];

            for (int i = 0; i < layers.Count; i++)
            {
                string str = layers[i];
                int zeroes = 0;
                int ones = 0;
                int twos = 0;
                foreach (char ch in str)
                {
                    switch (ch)
                    {
                        case '0':
                            zeroes++;
                            break;
                        case '1':
                            ones++;
                            break;
                        case '2':
                            twos++;
                            break;
                        default:
                            break;
                    }
                }
                zeroesArray[i] = zeroes;
                onesArray[i] = ones;
                twosArray[i] = twos;
            }

            int minLayerIndex = Array.IndexOf(zeroesArray, zeroesArray.Min());

            int partOneResult = onesArray[minLayerIndex] * twosArray[minLayerIndex];
            Console.WriteLine("Part One: " + partOneResult);

            // Part Two

            int[] image = new int[height * width];

            for (int i = 0; i < height * width; i++)
            {
                int pixel = 2;

                foreach (string layer in layers)
                {
                    if (layer[i] == '0')
                    {
                        pixel = 0;
                        break;
                    }
                    else if (layer[i] == '1')
                    {
                        pixel = 1;
                        break;
                    }
                }

                image[i] = pixel;
            }

            Console.WriteLine("Part Two:");
            PrintImage(image, height, width);
        }

        static void PrintImage(int[] image, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                string row = "";
                for (int j = 0; j < width; j++)
                {
                    char px = image[i * width + j] == 1 ? '\u2588' : ' ';
                    row += px;
                }
                Console.WriteLine(row);
            }
        }
    }
}
