using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
	static void Main(string[] args)
	{
		//Instance of the arena class
		Arena arena = new Arena();
		//calling the printall of the arena instance
		arena.PrintAll();
		//Waits for user input before closing program
		Console.ReadLine();
	}
}
