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
        static int bank = 1000;
        static int bet;

        static void Main()
        {
            Game();
        }
        static void NewDeck()
        {
            for (int i = 1; i < 13; i++)
            {
                cards.Add(new Card(Suit.Clubs, i, i.ToString()));
                cards.Add(new Card(Suit.Diamonds, i, i.ToString()));
                cards.Add(new Card(Suit.Hearts, i, i.ToString()));
                cards.Add(new Card(Suit.Spades, i, i.ToString()));
            }
        }
        static void Shuffler()
        {
            var shuffledcards = cards.OrderBy(a => Guid.NewGuid()).ToList(); //cards shuffling
            for (int i = 0; i < 5; i++)
            {
                chosencards.Add(new Card(shuffledcards[i].Suit, shuffledcards[i].Value, shuffledcards[i].Name)); // writing cards to a new class
                //Console.WriteLine(shuffledcards[i].Value + " + " + shuffledcards[i].Suit);
                shuffledcards.Remove(shuffledcards[i]); // removing cards

                switch (chosencards[i].Name)
                {
                    case "1":
                        chosencards[i].Name = "Ace";
                        break;
                    case "11":
                        chosencards[i].Name = "Jack";
                        break;
                    case "12":
                        chosencards[i].Name = "Queen";
                        break;
                    case "13":
                        chosencards[i].Name = "King";
                        break;
                    default:
                        break;
                }
            }

        }
        static void Game()
        {
            Console.WriteLine("Welcome in my Higher/Lower Game\n");
            Console.WriteLine("Rules: \nYou receive 3 cards from the deck, \nyou choose one of cards and you have to type if next draw card is higher or lower than yours.");
            Console.WriteLine("\nIf you choose correctly, you win, if not - you lose!\n");

            Console.WriteLine("There is a one more thing. You have {0:C} and you can bet to make yourself rich!",bank);
            Console.WriteLine("It's simple - you can bet 1, 5, 25, 50, 100 - input your bet:");

            BankBets();
            NewDeck();
            Shuffler();

            Console.WriteLine("Press enter to show three cards:");
            Console.ReadLine();
            Console.WriteLine("1: {0} {1}", chosencards[1].Name, chosencards[1].Suit);
            Console.WriteLine("2: {0} {1}", chosencards[2].Name, chosencards[2].Suit);
            Console.WriteLine("3: {0} {1}", chosencards[3].Name, chosencards[3].Suit);

            CardChoose();

            HiLo();
            Console.WriteLine("You have {0:C} in cash.", bank);

            BankCheck();

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
                        Console.WriteLine("Goodbye, you ended your game with {0:C}.", bank);
                        Console.WriteLine("Press any key...");
                        Console.ReadLine();
                        break;
                    }
                default:
                    Again();
                    break;
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
                            Console.WriteLine("BRAWO! Card {0} is lower than card {1}, you won!", chosencards[choose].Name, chosencards[4].Name);
                            bank += bet;
                            break;
                        }
                        else
                            Console.WriteLine("Unfortunately, card {0} is not lower than card {1}, you lose!", chosencards[choose].Name, chosencards[4].Name);
                        bank -= bet;
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
                            Console.WriteLine("BRAWO! Card {0} is higher than card {1}, you won!", chosencards[choose].Name, chosencards[4].Name);
                            bank += bet;
                            break;
                        }
                        else
                            Console.WriteLine("Unfortunately, card {0} is not higher than {1}, you lose!", chosencards[choose].Name, chosencards[4].Name);
                            bank -= bet;
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
        static void BankBets()
        {
            string input = Console.ReadLine();
            //bet = int.Parse(input);

            if (!int.TryParse(input, out choose))
            {
                Console.WriteLine("1, 5, 25, 50, 100...?");
                BankBets();
            }
            else
            {
                switch (choose)
                {
                    case 1:
                    case 5:
                    case 25:
                    case 50:
                    case 100:
                        bet = choose;
                        break;
                    default:
                        Console.WriteLine("Wrong answer, try again");
                        BankBets();
                        break;
                }
            }
        }
        static void BankCheck()
        {
            if (bank <= 0)
            {
                Console.WriteLine("You lost all your money. GAME OVER.");
                System.Environment.Exit(0);
            }
        }
    }
}
