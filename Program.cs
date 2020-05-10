using System;
using System.Collections.Generic;
using System.Linq;

namespace HigherLower
{
    class Program
    {
        static readonly List<Card> cards = new List<Card>();
        static readonly List<Card> chosencards = new List<Card>();
        static string lh;
        static int choose;

        static void Main(string[] args)
        {
            Game();
        }
        static void NewDeck()
        {
            for (int i = 1; i < 13; i++)
            {
                cards.Add(new Card(Suit.Clubs, i));
                cards.Add(new Card(Suit.Diamonds, i));
                cards.Add(new Card(Suit.Hearts, i));
                cards.Add(new Card(Suit.Spades, i));
            }
        }
        static void ShufflerChoser()
        {
            var shuffledcards = cards.OrderBy(a => Guid.NewGuid()).ToList(); //cards shuffling
            for (int i = 0; i < 5; i++)
            {
                chosencards.Add(new Card(shuffledcards[i].Suit, shuffledcards[i].Value)); // writing cards to a new class
                //Console.WriteLine(shuffledcards[i].Value + " + " + shuffledcards[i].Suit);
                shuffledcards.Remove(shuffledcards[i]); // removing cards
            }
        }
        static void Game()
        {
            Console.WriteLine("Welcome in my Higher/Lower Game\n");
            Console.WriteLine("Rules: \n You receive 3 cards from the deck, you choose one of cards and you have to type if next draw card is higer or lower than yours");
            Console.WriteLine("\nIf you choose correctly, you win, if not - you lose!\n");

            NewDeck();
            ShufflerChoser();

            Console.WriteLine("1: {0} {1}", chosencards[1].Value.ToString(), chosencards[1].Suit);
            Console.WriteLine("2: {0} {1}", chosencards[2].Value.ToString(), chosencards[2].Suit);
            Console.WriteLine("3: {0} {1}", chosencards[3].Value.ToString(), chosencards[3].Suit);

            CardChoose();

            HiLo();
            
            Again();
        }
        static void Again()
        {
            Console.WriteLine("Would you play again? Yes/No");
            string again = Console.ReadLine();
            switch (again)
            {
                case "Yes":
                case "YES":
                case "Y":
                case "y":
                    {
                        Console.Clear();
                        cards.Clear();
                        chosencards.Clear();
                        Game();
                        break;
                    };
                case "No":
                case "NO":
                case "N":
                case "n":
                    {
                        break;
                    }
            }
        }
        static void HiLo()
        {
            Console.WriteLine("\nYour card is lower, or higher?");
            lh = Console.ReadLine();
            switch (lh)
            {
                case "lower":
                case "Lower":
                case "LOWER":
                case "L":
                case "l":
                    {
                        if (chosencards[choose].Value < chosencards[4].Value)
                        {
                            Console.WriteLine("BRAWO! Card {0} is lower than card {1}, you won!", chosencards[choose].Value, chosencards[4].Value);
                        }
                        else
                            Console.WriteLine("Unfortunately, card {0} is not lower than card {1}, you lose!", chosencards[choose].Value, chosencards[4].Value);
                        break;
                    }
                case "Higher":
                case "higher":
                case "HIGHER":
                case "H":
                case "h":
                    {
                        if (chosencards[choose].Value > chosencards[4].Value)
                        {
                            Console.WriteLine("BRAWO! Card {0} is higher than card {1}, you won!", chosencards[choose].Value, chosencards[4].Value);
                        }
                        else
                            Console.WriteLine("Unfortunately, card {0} is not higher than {1}, you lose!", chosencards[choose].Value, chosencards[4].Value);
                        break;
                    }
                default:
                    Console.WriteLine("Wrong answer, try again");
                    HiLo();
                    break;
            }
        }
        static void CardChoose()
        {
            Console.WriteLine("\nWhich card do you choose?");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choose))
            {
                Console.WriteLine("Numbers 1 or 2 or 3 only!");
                CardChoose();
            }
            else
            {
                switch (choose)
                {
                    case 1:
                    case 2:
                    case 3:
                        break;

                    default:

                        Console.WriteLine("Wrong answer, try again");
                        CardChoose();
                        break;
                }
            }
        }
    }

}
