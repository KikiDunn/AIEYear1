using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player
{
	int ID;
	BufferEngine engine;
	public Player(BufferEngine engine)
	{
		this.engine = engine;
		ConsoleColor[,] playerSprite = new ConsoleColor[25, 10];
		for (int i = 0; i < playerSprite.GetLength(1); i++)
		{
			for (int j = 0; j < playerSprite.GetLength(0); j++)
			{
				playerSprite[j, i] = ConsoleColor.Blue;
			}
		}
		ID = engine.addSprite(playerSprite, 0, 0, false);
	}
	public void moveUp()
	{
		engine.moveSprite(ID, 0, -1);
	}
	public void moveDown()
	{
		engine.moveSprite(ID, 0, 1);
	}
	public void moveLeft()
	{
		engine.moveSprite(ID, -2.5, 0);
	}
	public void moveRight()
	{
		engine.moveSprite(ID, 2.5, 0);
	}
	public void rotateLeft()
	{
		engine.rotateSprite(ID, -1);
	}
	public void rotateRight()
	{
		engine.rotateSprite(ID, 1);
	}
}

