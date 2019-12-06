using System;

namespace Day_5
{
    class Program
    {
        static void Main()
        {
            string rawInput = "3,225,1,225,6,6,1100,1,238,225,104,0,1101,34,7,225,101,17,169,224,1001,224,-92,224,4,224,1002,223,8,223,1001,224,6,224,1,224,223,223,1102,46,28,225,1102,66,83,225,2,174,143,224,1001,224,-3280,224,4,224,1002,223,8,223,1001,224,2,224,1,224,223,223,1101,19,83,224,101,-102,224,224,4,224,102,8,223,223,101,5,224,224,1,223,224,223,1001,114,17,224,1001,224,-63,224,4,224,1002,223,8,223,1001,224,3,224,1,223,224,223,1102,60,46,225,1101,7,44,225,1002,40,64,224,1001,224,-1792,224,4,224,102,8,223,223,101,4,224,224,1,223,224,223,1101,80,27,225,1,118,44,224,101,-127,224,224,4,224,102,8,223,223,101,5,224,224,1,223,224,223,1102,75,82,225,1101,40,41,225,1102,22,61,224,1001,224,-1342,224,4,224,102,8,223,223,1001,224,6,224,1,223,224,223,102,73,14,224,1001,224,-511,224,4,224,1002,223,8,223,101,5,224,224,1,224,223,223,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,1008,677,677,224,1002,223,2,223,1006,224,329,1001,223,1,223,1007,226,226,224,1002,223,2,223,1005,224,344,101,1,223,223,1008,226,226,224,1002,223,2,223,1006,224,359,101,1,223,223,8,226,677,224,102,2,223,223,1006,224,374,101,1,223,223,1107,677,226,224,1002,223,2,223,1005,224,389,101,1,223,223,1008,677,226,224,102,2,223,223,1006,224,404,1001,223,1,223,1108,677,677,224,102,2,223,223,1005,224,419,1001,223,1,223,1107,677,677,224,102,2,223,223,1006,224,434,1001,223,1,223,1108,226,677,224,1002,223,2,223,1006,224,449,101,1,223,223,8,677,226,224,1002,223,2,223,1005,224,464,101,1,223,223,108,226,677,224,102,2,223,223,1005,224,479,1001,223,1,223,1107,226,677,224,102,2,223,223,1005,224,494,101,1,223,223,108,677,677,224,1002,223,2,223,1005,224,509,1001,223,1,223,7,677,226,224,1002,223,2,223,1006,224,524,101,1,223,223,1007,677,677,224,1002,223,2,223,1006,224,539,1001,223,1,223,107,226,226,224,102,2,223,223,1006,224,554,101,1,223,223,107,677,677,224,102,2,223,223,1006,224,569,1001,223,1,223,1007,226,677,224,1002,223,2,223,1006,224,584,101,1,223,223,108,226,226,224,102,2,223,223,1006,224,599,1001,223,1,223,7,226,226,224,102,2,223,223,1006,224,614,1001,223,1,223,8,226,226,224,1002,223,2,223,1006,224,629,1001,223,1,223,7,226,677,224,1002,223,2,223,1005,224,644,101,1,223,223,1108,677,226,224,102,2,223,223,1006,224,659,101,1,223,223,107,226,677,224,102,2,223,223,1006,224,674,1001,223,1,223,4,223,99,226";
            int[] input = ProcessInput(rawInput);


            // Part 1
            // PartOneAnswer(input, 1);
            // Console.WriteLine("End Part 1.");

            // Part 2
            PartOneAnswer(input, 5);
            Console.WriteLine("End Part 2.");
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

        static void PartOneAnswer(int[] input, int inputValue)
        {
            int i = 0;

            while (i < input.Length)
            {
                if (input[i] != 99)
                {
                    switch (input[i])
                    {
                        case 1:
                            input[input[i + 3]] = input[input[i + 1]] + input[input[i + 2]];
                            i += 4;
                            break;
                        case 2:
                            input[input[i + 3]] = input[input[i + 1]] * input[input[i + 2]];
                            i += 4;
                            break;
                        case 3:
                            input[input[i + 1]] = inputValue;
                            i += 2;
                            break;
                        case 4:
                            Console.WriteLine(input[input[i + 1]]);
                            i += 2;
                            break;
                        case 5:
                            if (input[input[i + 1]] != 0)
                            {
                                i = input[input[i + 2]];
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 6:
                            if (input[input[i + 1]] == 0)
                            {
                                i = input[input[i + 2]];
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 7:
                            if (input[input[i + 1]] < input[input[i + 2]])
                            {
                                input[input[i + 3]] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[input[i + 3]] = 0;
                                i += 4;
                            }
                            break;
                        case 8:
                            if (input[input[i + 1]] == input[input[i + 2]])
                            {
                                input[input[i + 3]] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[input[i + 3]] = 0;
                                i += 4;
                            }
                            break;

                        case 101:
                            input[input[i + 3]] = input[i + 1] + input[input[i + 2]];
                            i += 4;
                            break;
                        case 102:
                            input[input[i + 3]] = input[i + 1] * input[input[i + 2]];
                            i += 4;
                            break;
                        case 103: // none seem to be present
                            break;
                        case 104:
                            Console.WriteLine(input[i + 1]);
                            i += 2;
                            break;
                        case 105:
                            if (input[i + 1] != 0)
                            {
                                i = input[input[i + 2]];
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 106:
                            if (input[i + 1] == 0)
                            {
                                i = input[input[i + 2]];
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 107:
                            if (input[i + 1] < input[input[i + 2]])
                            {
                                input[input[i + 3]] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[input[i + 3]] = 0;
                                i += 4;
                            }
                            break;
                        case 108:
                            if (input[i + 1] == input[input[i + 2]])
                            {
                                input[input[i + 3]] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[input[i + 3]] = 0;
                                i += 4;
                            }
                            break;

                        case 1001:
                            input[input[i + 3]] = input[input[i + 1]] + input[i + 2];
                            i += 4;
                            break;
                        case 1101:
                            input[input[i + 3]] = input[i + 1] + input[i + 2];
                            i += 4;
                            break;
                        case 1002:
                            input[input[i + 3]] = input[input[i + 1]] * input[i + 2];
                            i += 4;
                            break;
                        case 1102:
                            input[input[i + 3]] = input[i + 1] * input[i + 2];
                            i += 4;
                            break;

                        case 1005:
                            if (input[input[i + 1]] != 0)
                            {
                                i = input[i + 2];
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 1105:
                            if (input[i + 1] != 0)
                            {
                                i = input[i + 2];
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 1006:
                            if (input[input[i + 1]] == 0)
                            {
                                i = input[i + 2];
                            }
                            else
                            {
                                i += 3;
                            }
                            break;
                        case 1106:
                            if (input[i + 1] == 0)
                            {
                                i = input[i + 2];
                            }
                            else
                            {
                                i += 3;
                            }
                            break;

                        case 1007:
                            if (input[input[i + 1]] < input[i + 2])
                            {
                                input[input[i + 3]] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[input[i + 3]] = 0;
                                i += 4;
                            }
                            break;

                        case 1107:
                            if (input[i + 1] < input[i + 2])
                            {
                                input[input[i + 3]] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[input[i + 3]] = 0;
                                i += 4;
                            }
                            break;

                        case 1008:
                            if (input[input[i + 1]] == input[i + 2])
                            {
                                input[input[i + 3]] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[input[i + 3]] = 0;
                                i += 4;
                            }
                            break;

                        case 1108:
                            if (input[i + 1] == input[i + 2])
                            {
                                input[input[i + 3]] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[input[i + 3]] = 0;
                                i += 4;
                            }
                            break;

                        case 10007:
                            if (input[input[i + 1]] < input[input[i + 2]])
                            {
                                input[i + 3] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[i + 3] = 0;
                                i += 4;
                            }
                            break;

                        case 10107:
                            if (input[i + 1] < input[input[i + 2]])
                            {
                                input[i + 3] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[i + 3] = 0;
                                i += 4;
                            }
                            break;

                        case 11007:
                            if (input[input[i + 1]] < input[i + 2])
                            {
                                input[i + 3] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[i + 3] = 0;
                                i += 4;
                            }
                            break;

                        case 11107:
                            if (input[i + 1] < input[i + 2])
                            {
                                input[i + 3] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[i + 3] = 0;
                                i += 4;
                            }
                            break;

                        case 10008:
                            if (input[input[i + 1]] == input[input[i + 2]])
                            {
                                input[i + 3] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[i + 3] = 0;
                                i += 4;
                            }
                            break;

                        case 10108:
                            if (input[i + 1] == input[input[i + 2]])
                            {
                                input[i + 3] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[i + 3] = 0;
                                i += 4;
                            }
                            break;

                        case 11008:
                            if (input[input[i + 1]] == input[i + 2])
                            {
                                input[i + 3] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[i + 3] = 0;
                                i += 4;
                            }
                            break;

                        case 11108:
                            if (input[i + 1] == input[i + 2])
                            {
                                input[i + 3] = 1;
                                i += 4;
                            }
                            else
                            {
                                input[i + 3] = 0;
                                i += 4;
                            }
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
        }
    }
}
