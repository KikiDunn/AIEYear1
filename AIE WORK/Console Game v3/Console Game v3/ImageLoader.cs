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
		
		Bitmap player = new Bitmap(@"..\..\Sprites\tank.png");
		sprites[0] = new int[player.Width, player.Height];
		for(int y = 0; y < player.Height; y++)
		{
			for (int x = 0; x < player.Width; x++)
			{
				sprites[0][x, y] = getClosestConsoleColour(player.GetPixel(x, y));
			}
		}
	}
	
	int getClosestConsoleColour(Color color)
	{

		Color[] cCs =
		{
				Color.Black,                        //Black
                Color.FromArgb(255,0,0,255),        //Dark Blue
                Color.FromArgb(255,0,128,0),        //Dark Green
                Color.FromArgb(255,0,128,128),      //Dark Cyan
                Color.FromArgb(255,128,0,0),        //Dark Red
                Color.FromArgb(255,128,0,128),      //Dark Magenta
                Color.FromArgb(255,128,128,0),      //Dark Yellow
                Color.FromArgb(255,192,192,192),    //Grey
                Color.FromArgb(255,128,128,128),    //Dark Grey
                Color.LightBlue,                    //Blue
                Color.FromArgb(255,0,255,0),                        //Green
                Color.Cyan,                         //Cyan
                Color.Red,                          //Red
                Color.Magenta,                      //Magenta
                Color.Yellow,                       //Yellow
                Color.White                         //White
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

