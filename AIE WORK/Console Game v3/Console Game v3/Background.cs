using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Background
{
	BufferEngine engine;
	int ID;
	public Background(BufferEngine engine)
	{
		int[,] background = new int[Console.BufferWidth*2, Console.BufferHeight*5];
		this.engine = engine;
		for (int y = 0; y < background.GetLength(1); y++)
		{
			for (int x = 0; x < background.GetLength(0); x++)
			{
				background[x, y] = (int)ConsoleColor.DarkGreen;
			}
		}
		ID = engine.addSprite(background, 0, 0, false);
	}
}

