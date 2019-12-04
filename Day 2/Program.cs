using System;

namespace AoC_Day_2
{
    class Program
    {
        static void Main()
        {
            string rawInput = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,5,23,1,23,9,27,2,27,6,31,1,31,6,35,2,35,9," +
                "39,1,6,39,43,2,10,43,47,1,47,9,51,1,51,6,55,1,55,6,59,2,59,10,63,1,6,63,67,2,6,67,71,1,71,5,75,2,13,75," +
                "79,1,10,79,83,1,5,83,87,2,87,10,91,1,5,91,95,2,95,6,99,1,99,6,103,2,103,6,107,2,107,9,111,1,111,5,115,1" +
                ",115,6,119,2,6,119,123,1,5,123,127,1,127,13,131,1,2,131,135,1,135,10,0,99,2,14,0,0";
            int[] input = ProcessInput(rawInput);
            

            // Part 1
            Console.WriteLine(PartOneAnswer(input, 12, 2));

            // Part 2 Calc

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    input = ProcessInput(rawInput);
                    int partTwoAnswer = PartOneAnswer(input, noun, verb);
                    if (partTwoAnswer == 19690720)
                    {
                        Console.WriteLine(100 * noun + verb);
                        break;
                    }
                }
            }
        }

        static int[] ProcessInput(string rawInput)
        {
            string[] split = rawInput.Split(",");
            int[] input = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                input[i] = Int32.Parse(split[i]);
            }

            return input;
        }

        static int PartOneAnswer(int[] input, int noun, int verb)
        {
            input[1] = noun;
            input[2] = verb;

            for (int i = 0; i < input.Length; i += 4)
            {
                if (input[i] != 99)
                {
                    switch (input[i])
                    {
                        case 1:
                            input[input[i + 3]] = input[input[i + 1]] + input[input[i + 2]];
                            break;
                        case 2:
                            input[input[i + 3]] = input[input[i + 1]] * input[input[i + 2]];
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    break;
                }
            }
            return input[0];
        }
    }
}
