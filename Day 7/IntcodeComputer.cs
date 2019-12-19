using System;

public class IntcodeComputer
{
    public string rawInput;
    public int[] input;

    public IntcodeComputer(string inputString)
    {
        rawInput = inputString;
        input = ProcessInput(rawInput);
    }

    public int Calculate(int phase, int inputValue)
    {
        int output = Intcode(phase, inputValue);
        return output;
    }

    private int[] ProcessInput(string rawInput)
    {
        string[] split = rawInput.Split(",");
        int[] input = new int[split.Length];

        for (int i = 0; i < split.Length; i++)
        {
            input[i] = Int32.Parse(split[i]);
        }

        return input;
    }

    private int Intcode(int phase, int inputValue)
    {
        int i = 0;
        int inputCounter = 0;

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
                        if (inputCounter == 0)
                        {
                            input[input[i + 1]] = phase;
                            inputCounter++;
                        }
                        else
                        {
                            input[input[i + 1]] = inputValue;
                        }
                        i += 2;
                        break;
                    case 4:
                        return input[input[i + 1]];
                    // i += 2;
                    // break;
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
                        return input[i + 1];
                    // i += 2;
                    // break;
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

        return 0;
    }
}
