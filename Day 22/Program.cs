using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_22
{
    class Program
    {
        static void Main()
        {
            // Inputs
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
            Console.WriteLine(result);
        }
    }
}
