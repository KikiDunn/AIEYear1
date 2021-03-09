using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
class Program
{
	static void Main(string[] args)
	{
		Vector2 pos = new Vector2(1,2);
		Vector2 pos2 = new Vector2(3,4);
		Vector2 thing = pos * 2;
		Console.WriteLine(thing.x + ", " + thing.y);
		Console.ReadLine();
	}
}

