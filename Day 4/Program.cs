using System;

namespace Day_4
{
    class Program
    {
        static void Main()
        {
            int rangeMin = 134564;
            int rangeMax = 585159;
            int counter = 0;

            for (int i = rangeMin; i <= rangeMax; i++)
            {
                string str = i.ToString();
                int[] intArray = new int[6];
                for (int j = 0; j < 6; j++)
                {
                    intArray[j] = Convert.ToInt32(str[j]);
                }

                // Check existence of repeated digit
                bool check1 = false;
                for (int j = 0; j < 5; j++)
                {
                    if (intArray[j] == intArray[j + 1])
                    {
                        check1 = true;
                    }
                }

                // Check digits are equal or descending
                bool check2 = true;
                for (int j = 0; j < 5; j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        check2 = false;
                    }
                }

                if (check1 & check2)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
            Console.WriteLine(Part2());
        }

        static int Part2()
        {
            int rangeMin = 134564;
            int rangeMax = 585159;
            int counter = 0;

            for (int i = rangeMin; i <= rangeMax; i++)
            {
                string str = i.ToString();
                int[] intArray = new int[6];
                for (int j = 0; j < 6; j++)
                {
                    intArray[j] = Convert.ToInt32(str[j]);
                }

                // Check existence of unique repeated digit
                bool check1 = false;
                for (int j = 0; j < 5; j++)
                {
                    bool a = intArray[j] == intArray[j + 1];
                    bool b = true;
                    if (j < 4)
                    {
                        b = intArray[j] != intArray[j + 2];
                    }
                    bool c = true;
                    if (j > 0)
                    {
                        c = intArray[j] != intArray[j - 1];
                    }
                    if (a & b & c)
                    {
                        check1 = true;
                    }
                }

                // Check digits are equal or descending
                bool check2 = true;
                for (int j = 0; j < 5; j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        check2 = false;
                    }
                }

                if (check1 & check2)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
