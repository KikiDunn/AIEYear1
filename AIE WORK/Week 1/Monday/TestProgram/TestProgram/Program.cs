using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        string inv = "Empty";

        Console.WriteLine("Welcome to my game\n*******************");
        Console.ReadLine();
        Console.WriteLine("(y/n)");
        Console.WriteLine("You wake up in your house would you like to start your adventure? ");

        string answer = Console.ReadLine();

        if (answer == "n")
        {
            Console.WriteLine("You go back to bed and drift into a long slumber.");
            Console.ReadLine();
        }
        else{
            
            Console.WriteLine("(type bow or sword)");
            Console.WriteLine("Would you like to equip a bow or sword? ");
            inv = Console.ReadLine();
            Console.WriteLine("You head out of your house equipped with your " + inv + ".");
            Console.ReadLine();

            Console.WriteLine("Out side your house there is two paths winding away from your doorstep.\nOne path heads south into a valley and the other leads north towards a mountain");
            Console.ReadLine();
            Console.WriteLine("(type north or south)");
            Console.WriteLine("Which path would you like to take?");
            string pathtaken = Console.ReadLine();
            string landmark;
            int encounter;
            if (pathtaken == "north")
            {
                landmark = "mountain";
                encounter = 1;
            }
            else
            {
                landmark = "valley";
                encounter = 2;
            }

            Console.WriteLine("Confident you are taking the right path you head " + pathtaken + " down the winding road towards the " + landmark + " in the distance.");
            Console.ReadLine();
            Console.WriteLine("The first few hours of your adventure are uneventful but it seems to be getting colder as you draw closer to the " + landmark + " and a thick mist seems to be gathering in the distance.");
            Console.ReadLine();
            Console.WriteLine("(y/n)");
            Console.WriteLine("Do you want to continue on your adventure?");
            string isContinue = Console.ReadLine();

            if (isContinue == "n")
            {
                Console.WriteLine("You scurry back along the path to your house, the mist seemingly chasing you all the way to your door.\n You are disapointed in your unadventful adventure but you drift asleep in your bed knowing you are safe.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your heart pounding you push onwards towards the " + landmark + " and you clutch your " + inv + " tightly as the mist envelops you.");
                Console.ReadLine();
                if (encounter == 1)
                {
                    Console.WriteLine("As you begin your ascent of the mountain you hear heavy thumping of large wings beating the air above you.");
                    Console.WriteLine("(type attack or retreat)");
                    Console.WriteLine("Would you like to attack or retreat?");
                    string turnBack = Console.ReadLine();
                    if (turnBack == "retreat")
                    {
                        Console.WriteLine("You flee desperately back down the mountain dropping your " + inv + " and the last thing you feel before losing conciusness is the heavy beating of wings behind your head and the excruciating pain of claws sinking into your back.");
                        Console.ReadLine();
                    }
                    else
                    {
                        if (inv == "bow")
                        {
                            Console.WriteLine("You attack the unseen beast with your bow launching arrows into the air and hear several meaty impacts before the sound of a large object crashing into the ground.");
                            Console.ReadLine();
                            Console.WriteLine("With the beast vanquished you find a small stash of treasure and make it back to your house after a successful adventure.");
                            Console.ReadLine();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("You swing wildly into the air with your sword and the last thing you see is a large monster decending form the sky on top of you before you feel your body being ripped apart by large claws");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("As you begin your descent into the valley you hear the sounds of heavy hoofs galloping towards you.");
                    Console.WriteLine("(type attack or retreat)");
                    Console.WriteLine("Would you like to attack or retreat?");
                    string turnBack = Console.ReadLine();
                    if (turnBack == "retreat")
                    {
                        Console.WriteLine("You flee desperately back up the valley dropping your " + inv + " and the last thing you feel before losing conciusness is the excruciating pain of tusks sinking into your back.");
                        Console.ReadLine();
                    }
                    else
                    {
                        if (inv == "sword")
                        {
                            Console.WriteLine("Just before the hoof beats reach you, you swing out with your sword and hear a meaty twack as it connects with the beast, before the monster falls to the ground");
                            Console.ReadLine();
                            Console.WriteLine("With the beast vanquished you find a small stash of treasure and make it back to your house after a successful adventure.");
                            Console.ReadLine();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("You shoot wildly at the approaching hoof beats but you can't tell if any of your arrows hit before a large beast leaps out of the mist and gores your chest with its tusks.");
                            Console.ReadLine();
                            Console.WriteLine("You hear the hoof beats recede into the distance as you slowly bleed out on the ground, and drift away as the valley claims your body.");
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}