using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player
{
	int ID;
	BufferEngine engine;
	int[,] playerSprite;
	public Player(BufferEngine engine, int[,] playerSprite)
	{
		this.engine = engine;
		this.playerSprite = playerSprite;
		ID = engine.addSprite(playerSprite, 0, 0, false);
	}
	public void moveUp()
	{
		engine.moveSprite(ID, Math.Cos((engine.getAngle(ID)-90)*Math.PI/180)*5, Math.Sin((engine.getAngle(ID) - 90) * Math.PI / 180)*5);
	}
	public void moveDown()
	{
		engine.moveSprite(ID, -Math.Cos((engine.getAngle(ID) - 90) * Math.PI / 180)*5, -Math.Sin((engine.getAngle(ID) - 90) * Math.PI / 180)*5);
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
		engine.rotateSprite(ID, -5);
	}
	public void rotateRight()
	{
		engine.rotateSprite(ID, 5);
	}
}

