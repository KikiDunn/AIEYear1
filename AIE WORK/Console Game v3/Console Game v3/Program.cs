using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
class Program
{
	static void Main(string[] args)
	{
		BufferEngine engine = new BufferEngine();
		Console.CursorVisible = false;
		ConsoleKeyInfo input = new ConsoleKeyInfo();
		bool quit = false;
		new Thread(() =>
		{
			Thread.CurrentThread.IsBackground = true;
			//input = Console.ReadKey();
			while (input.Key != ConsoleKey.Q)
			{
				input = Console.ReadKey();
				//input2 = Console.Read();
			}
			quit = true;
		}).Start();
		new Thread(() =>
		{
			Thread.CurrentThread.IsBackground = true;
			while (!quit)
			{
				switch (input.Key)
				{
					case ConsoleKey.W:

						input = new ConsoleKeyInfo();
						break;
					case ConsoleKey.A:

						input = new ConsoleKeyInfo();
						break;
					case ConsoleKey.S:

						input = new ConsoleKeyInfo();
						break;
					case ConsoleKey.D:

						input = new ConsoleKeyInfo();
						break;
				}
			}
		}).Start();
		while (!quit)
		{
			engine.print();
		}
	}
}

