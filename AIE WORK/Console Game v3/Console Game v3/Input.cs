using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

class Input
{
	bool quit = false;
	public Input(Player player)
	{
		ConsoleKeyInfo input = new ConsoleKeyInfo();
		
		new Thread(() =>
		{
			Thread.CurrentThread.IsBackground = true;
			//input = Console.ReadKey();
			while (input.Key != ConsoleKey.Escape)
			{
				input = Console.ReadKey(true);
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
						player.moveUp();
						input = new ConsoleKeyInfo();
						break;
					case ConsoleKey.A:
						player.rotateLeft();
						input = new ConsoleKeyInfo();
						break;
					case ConsoleKey.S:
						player.moveDown();
						input = new ConsoleKeyInfo();
						break;
					case ConsoleKey.D:
						player.rotateRight();
						input = new ConsoleKeyInfo();
						break;
				}
			}
		}).Start();
	}
	public bool isQuit()
	{
		return quit;
	}
}

