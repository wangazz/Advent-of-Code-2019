using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Day_22
{
    class Program
    {
        static void Main()
        {
            // Part 1 Inputs
            int cards = 10007;
            string[] instructions = File.ReadAllLines("Input.txt");

            // Initialise deck
            int[] deck = new int[cards];
            for (int card = 0; card < cards; card++)
            {
                deck[card] = card;
            }

            // Perform shuffles
            for (int instr = 0; instr < instructions.Length; instr++)
            {
                string thisInstruction = instructions[instr];

                if (thisInstruction == "deal into new stack")
                {
                    Array.Reverse(deck);
                }
                else if (thisInstruction.Contains("cut"))
                {
                    Regex exp = new Regex(@"-?\d+");
                    int cut = Convert.ToInt32(exp.Match(thisInstruction).Value);
                    if (cut < 0) cut = cards + cut;

                    var topPart = deck.Take(cut);
                    var bottomPart = deck.Skip(cut).Take(cards - cut);

                    int[] newDeck = bottomPart.Concat(topPart).ToArray();
                    deck = newDeck;
                }
                else if (thisInstruction.Contains("deal with increment"))
                {
                    Regex exp = new Regex(@"\d+");
                    int inc = Convert.ToInt32(exp.Match(thisInstruction).Value);

                    int[] newDeck = new int[cards];
                    int newIndex = 0;
                    for (int i = 0; i < cards; i++)
                    {
                        int thisCard = deck[i];
                        newDeck[newIndex] = thisCard;
                        newIndex = (newIndex + inc) % cards;
                    }

                    deck = newDeck;
                }
            }

            // Part 1 Answer
            int result = Array.IndexOf(deck, 2019);
            Console.WriteLine("Part 1 Solution: " + result);


            // Part 2 Inputs
            BigInteger cards_2 = 119315717514047;
            BigInteger iterations = 101741582076661;

            // All possible decks can be described by (offset, increment) such that
            // the nth card is given by (offset + n * increment) % cards
            BigInteger offset = 0;
            BigInteger increment = 1;

            // Perform 1 shuffle sequence
            for (int instr = 0; instr < instructions.Length; instr++)
            {
                string thisInstruction = instructions[instr];

                if (thisInstruction == "deal into new stack")
                {
                    increment *= -1;
                    offset += increment;
                }
                else if (thisInstruction.Contains("cut"))
                {
                    Regex exp = new Regex(@"-?\d+");
                    int cut = Convert.ToInt32(exp.Match(thisInstruction).Value);
                    offset += increment * cut;
                }
                else if (thisInstruction.Contains("deal with increment"))
                {
                    Regex exp = new Regex(@"\d+");
                    int inc = Convert.ToInt32(exp.Match(thisInstruction).Value);

                    increment *= BigInteger.ModPow(inc, cards_2 - 2, cards_2);
                }
            }

            // Exponentiate over all iterations
            offset = offset * (1 - BigInteger.ModPow(increment, iterations, cards_2)) * BigInteger.ModPow(1 - increment, cards_2 - 2, cards_2);
            increment = BigInteger.ModPow(increment, iterations, cards_2);

            // Part 2 Solution
            BigInteger result_2 = (offset + increment * 2020) % cards_2;
            result_2 = result_2 >= 0 ? result_2 : result_2 + cards_2;
            Console.WriteLine("Part 2 Solution: " + result_2);
        }
    }
}
