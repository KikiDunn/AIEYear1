using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
class ImageLoader
{
	int[][,] sprites = new int[10][,];
	public ImageLoader()
	{
		
		Bitmap player = new Bitmap(@"..\..\Sprites\TankChasis.png");
		sprites[0] = new int[player.Width, player.Height];
		for(int y = 0; y < player.Height; y++)
		{
			for (int x = 0; x < player.Width; x++)
			{
				sprites[0][x, y] = getClosestConsoleColour(player.GetPixel(x, y));
			}
		}
		player = new Bitmap(@"..\..\Sprites\Turret1.png");
		sprites[1] = new int[player.Width, player.Height];
		for (int y = 0; y < player.Height; y++)
		{
			for (int x = 0; x < player.Width; x++)
			{
				sprites[1][x, y] = getClosestConsoleColour(player.GetPixel(x, y));
			}
		}
		player = new Bitmap(@"..\..\Sprites\Turret2.png");
		sprites[2] = new int[player.Width, player.Height];
		for (int y = 0; y < player.Height; y++)
		{
			for (int x = 0; x < player.Width; x++)
			{
				sprites[2][x, y] = getClosestConsoleColour(player.GetPixel(x, y));
			}
		}
		player = new Bitmap(@"..\..\Sprites\Turret3.png");
		sprites[3] = new int[player.Width, player.Height];
		for (int y = 0; y < player.Height; y++)
		{
			for (int x = 0; x < player.Width; x++)
			{
				sprites[3][x, y] = getClosestConsoleColour(player.GetPixel(x, y));
			}
		}
		player = new Bitmap(@"..\..\Sprites\Turret4.png");
		sprites[4] = new int[player.Width, player.Height];
		for (int y = 0; y < player.Height; y++)
		{
			for (int x = 0; x < player.Width; x++)
			{
				sprites[4][x, y] = getClosestConsoleColour(player.GetPixel(x, y));
			}
		}
		player = new Bitmap(@"..\..\Sprites\Turret5.png");
		sprites[5] = new int[player.Width, player.Height];
		for (int y = 0; y < player.Height; y++)
		{
			for (int x = 0; x < player.Width; x++)
			{
				sprites[5][x, y] = getClosestConsoleColour(player.GetPixel(x, y));
			}
		}
		player = new Bitmap(@"..\..\Sprites\laser.png");
		sprites[6] = new int[player.Width, player.Height];
		for (int y = 0; y < player.Height; y++)
		{
			for (int x = 0; x < player.Width; x++)
			{
				sprites[5][x, y] = getClosestConsoleColour(player.GetPixel(x, y));
			}
		}
	}
	
	int getClosestConsoleColour(Color color)
	{

		Color[] cCs =
		{
				Color.Black,                         //Black
                Color.FromArgb(255,0,55,218),        //Dark Blue
                Color.FromArgb(255,19,161,14),       //Dark Green
                Color.FromArgb(255,58,150,221),      //Dark Cyan
                Color.FromArgb(255,128,15,31),       //Dark Red
                Color.FromArgb(255,136,21,152),      //Dark Magenta
                Color.FromArgb(255,128,128,0),       //Dark Yellow
                Color.FromArgb(255,204,204,204),     //Grey
                Color.FromArgb(255,118,118,118),     //Dark Grey
                Color.FromArgb(255,59, 120, 255),    //Blue
                Color.FromArgb(255,22, 198, 12),     //Green
                Color.FromArgb(255,97, 214, 213),    //Cyan
                Color.FromArgb(255,231, 72, 86),     //Red
                Color.FromArgb(255,180, 0, 158),     //Magenta
                Color.FromArgb(255,249, 241, 165),   //Yellow
                Color.FromArgb(255,242, 242, 242)    //White
        };
		if(color.A < 128)
		{
			return -1;
		}
		float[] distance = new float[cCs.Length];
		for (int x = 0; x < cCs.Length; x++)
		{
			Vector3 vector = new Vector3(cCs[x].R - color.R, cCs[x].G - color.G, cCs[x].B - color.B);
			distance[x] = vector.Length();
		}
		float big = 999999;
		int number = 0;

		int i = 0;

		for (; i < distance.Length; i++)
		{
			if (distance[i] < big)
			{
				big = distance[i];
				number = i;
			}
		}
		return number;
	}
	public int[,] getSprite(int ID)
	{
		return sprites[ID];
	}
}

