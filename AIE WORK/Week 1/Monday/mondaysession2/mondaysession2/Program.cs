using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mondaysession2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool phit = true;
            bool dhit = true;
            int dcards = 0;
            int dtotal = 0;
            int d1 = 0;
            int d2 = 0;
            int d3 = 0;
            int d4 = 0;
            int d5 = 0;
            int pcards = 0;
            int ptotal = 0;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            int deal;
            string dealer = "Dealers cards: ";
            string dealerend = "Dealers cards: ";
            
            Random random = new Random();
            Console.WriteLine("Wemcome to blackjack");
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            string player = name +"'s cards: ";
            Console.WriteLine("Press p to play or q to quit");
            string input = Console.ReadLine();

            while (!(input == "q"))
            {
                input = "h";
                phit = true;
                dhit = true;
                dcards = 0;
                dtotal = 0;
                d1 = 0;
                d2 = 0;
                d3 = 0;
                d4 = 0;
                d5 = 0;
                pcards = 0;
                ptotal = 0;
                p1 = 0;
                p2 = 0;
                p3 = 0;
                p4 = 0;
                p5 = 0;
                dealer = "Dealers cards: ";
                dealerend = "Dealers cards: ";
                player = name + "'s cards: ";
                Console.WriteLine("Starting game press enter to continue");
                Console.ReadLine();
                
                while ((ptotal <= 21)|| (dtotal <= 21))
                {
                    Console.Clear();
                    
                    if (phit)
                    {
                        Console.WriteLine("Dealer deals you one card...");
                        deal = random.Next(1, 13);
                        if (deal > 11)
                        {
                            deal = 11;
                        }
                        if (pcards == 0)
                        {
                            p1 = deal;
                            player = player + " " + p1;
                        }
                        if (pcards == 1)
                        {
                            p2 = deal;
                            player = player + ", " + p2;
                        }
                        if (pcards == 2)
                        {
                            p3 = deal;
                            player = player + ", " + p3;
                        }
                        if (pcards == 3)
                        {
                            p4 = deal;
                            player = player + ", " + p4;
                        }
                        if (pcards == 4)
                        {
                            p5 = deal;
                            player = player + ", " + p5;
                        }
                        pcards++;
                    }
                    Console.WriteLine(player);
                    ptotal = p1 + p2 + p3 + p4 + p5;
                    Console.WriteLine(name + "'s total: "+ptotal);
                    Console.WriteLine("press enter to continue...");
                    Console.ReadLine();
                    
                    if (ptotal > 21)
                    {
                        Console.WriteLine("You Lose, Total: " + ptotal);
                        Console.WriteLine(dealerend);
                        break;
                    }else if (pcards == 5)
                    {
                        Console.WriteLine("You win!");
                        Console.WriteLine("You got to 5 cards before 21.");
                        Console.WriteLine("Your total: " + ptotal + " " + player);
                        Console.WriteLine("Dealer total: " + dtotal + " " + dealerend);
                        Console.WriteLine("press enter to continue...");
                    }
                    if (dtotal > 16)
                    {
                        dhit = false;
                    }
                    if (dhit)
                    {
                        Console.WriteLine("Dealer hits.");
                        deal = random.Next(1, 13);
                        if (deal > 11)
                        {
                            deal = 11;
                        }
                        if (dcards == 0)
                        {
                            d1 = deal;
                            dealer = dealer + " " + d1;
                            dealerend = dealerend + " " + d1;
                        }
                        if (dcards == 1)
                        {
                            d2 = deal;
                            dealer = dealer + " *face down card";
                            dealerend = dealerend + ", " + d2;
                        }
                        if (dcards == 2)
                        {
                            d3 = deal;
                            dealer = dealer + " *face down card";
                            dealerend = dealerend + ", " + d3;
                        }
                        if (dcards == 3)
                        {
                            d4 = deal;
                            dealer = dealer + " *face down card";
                            dealerend = dealerend + ", " + d4;
                        }
                        if (dcards == 4)
                        {
                            d5 = deal;
                            dealer = dealer + " *face down card";
                            dealerend = dealerend + ", " + d4;
                        }
                        dcards++;
                    }
                    else
                    {
                        Console.WriteLine("Dealer stays.");
                        if (phit == false)
                        {
                            dtotal = d1 + d2 + d3 + d4 + d5;
                            ptotal = p1 + p2 + p3 + p4 + p5;
                            if (dtotal > ptotal)
                            {
                                Console.WriteLine("Dealer wins!");
                                Console.WriteLine("Dealer total: " + dtotal + " " + dealerend);
                                Console.WriteLine("Your total: " + ptotal + " " + player);
                                Console.WriteLine("press enter to continue...");
                                Console.ReadLine();
                                break;
                            }
                            else if(dtotal < ptotal)
                            {
                                Console.WriteLine("You win!");
                                Console.WriteLine("Your total: " + ptotal + " " + player);
                                Console.WriteLine("Dealer total: " + dtotal + " " + dealerend);
                                Console.WriteLine("press enter to continue...");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("DRAW!");
                                Console.WriteLine("Your total: " + ptotal + " " + player);
                                Console.WriteLine("Dealer total: " + dtotal + " " + dealerend);
                                Console.WriteLine("press enter to continue...");
                                Console.ReadLine();
                                break;
                            }
                        }
                    }
                    Console.WriteLine(dealer);
                    
                    dtotal = d1 + d2 + d3 + d4 + d5;
                    if(dtotal > 21)
                    {
                        Console.WriteLine("You Win, Total: " + ptotal);
                        Console.WriteLine("Dealer Loses, Dealer Total: " + dtotal);
                        Console.WriteLine(dealerend);
                        break;
                    }else if(dcards == 5)
                    {
                        Console.WriteLine("Dealer wins!");
                        Console.WriteLine("They got to 5 cards before 21.");
                        Console.WriteLine("Dealer total: " + dtotal + " " + dealerend);
                        Console.WriteLine("Your total: " + ptotal + " " + player);
                        Console.WriteLine("press enter to continue...");
                    }
                    if (input == "h")
                    {
                        do
                        {
                            Console.WriteLine("Would you like to hit or stay? press h or s.");
                            input = Console.ReadLine();

                            if (input == "h")
                            {
                                phit = true;
                            }
                            else if (input == "s")
                            {
                                phit = false;
                            }
                        } while (!(input == "h" || input == "s"));
                    }
                }

                Console.WriteLine("Press p to play or q to quit");
                input = Console.ReadLine();
            }
            Console.WriteLine("Thanks for playing!");
            Console.ReadLine();
        }
            
        
    }
}
