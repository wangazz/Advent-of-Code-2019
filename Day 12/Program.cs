using System;
using System.Collections.Generic;
using System.IO;

namespace Day_12
{
    class Program
    {
        static void Main()
        {
            int steps = 1000;
            string[] input = File.ReadAllLines("input.txt");
            int[][] position = new int[steps * 4][];
            int[][] velocity = new int[steps * 4][];

            // parse input
            for (int i = 0; i < input.Length; i++)
            {
                // set initial position
                string str = input[i];
                char[] charsToTrim = { '<', '>' };
                str = str.Trim(charsToTrim);
                string[] strArray = str.Split(", ");

                int[] array = new int[3];
                for (int j = 0; j < strArray.Length; j++)
                {
                    array[j] = Convert.ToInt32(strArray[j].Substring(2));
                }
                position[i] = array;

                //set initial velocity
                int[] vel = {0,0,0};
                velocity[i] = vel;
            }

            // loop over time steps
            for (int step = 1; step <= steps; step ++)
            {
                int arrayIndex = step * 4;
                // apply gravity
                for (int a = 0; a < 4; a++)
                {
                    for (int b = 0; b < 4; b++)
                    {
                        if (a != b)
                        {
                            // compare positions
                            for (int dim = 0; dim < 3; dim++)
                            {
                                int x1 = position[arrayIndex + a][dim];
                                int x2 = position[arrayIndex + b][dim];
                                if (x1 < x2)
                                {
                                    velocity[arrayIndex + a][dim]++;
                                    velocity[arrayIndex + b][dim]--;
                                }
                                else if (x1 > x2)
                                {
                                    velocity[arrayIndex + a][dim]--;
                                    velocity[arrayIndex + b][dim]++;
                                }
                            }
                        }
                    }
                }

                // apply velocity
                for (int a = 0; a < 4; a++)
                {
                    
                }

            }
        }
    }
}
