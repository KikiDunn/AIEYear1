using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PixelEngine
{		
	int width = 50;
	int height = 50;
	String back;
	ConsoleColor[,] framedata;
	Chunk[] frame;
	List<Sprite> sprites = new List<Sprite>();
	int spriteCount = 0;
	int chunkCount = 0;
	ConsoleColor[,] background;
	public PixelEngine()
	{
		framedata = new ConsoleColor[width, height];
		background = new ConsoleColor[width, height];
		frame = new Chunk[width * height];
		back = String.Concat(Enumerable.Repeat(String.Concat(Enumerable.Repeat("  ", width )) + "\n", height));
		for (int i = 0; i < background.GetLength(0); i++)
		{
			for (int j = 0; j < background.GetLength(1); j++)
			{
				background[i, j] = ConsoleColor.White;
            }
        }
    }
    public void square()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(back);
    }
    public void addSprite(ConsoleColor[,] pixels, int posX, int posY, bool hidden)
    {
        Sprite temp = new Sprite();
        temp.pixels = pixels;
        temp.hidden = hidden;
        temp.x = posX;
        temp.y = posY;
        sprites.Add(temp);
        spriteCount++;
    }
    public void moveSprite(int ID, int posX, int posY)
    {
        sprites[ID].x += posX;
        sprites[ID].y += posY;
    }
    public void hideSprite(int ID, bool hidden)
    {
        sprites[ID].hidden = hidden;
    }
    public void draw(Chunk[] frame)
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < frame.Length; i++)
        {
            Console.BackgroundColor = frame[i].colour;
            Console.Write(frame[i].chunk);
        }
    }
    public void writeToFrame()
    {
        //framedata = background;
        for (int i = 0; i < framedata.GetLength(0); i++)
        {
            for (int j = 0; j < framedata.GetLength(1); j++)
            {
                framedata[i, j] = background[i, j];
            }
        }
        for (int i = 0; i < spriteCount; i++)
        {
            
            if(sprites[i].x <= 133 && sprites[i].x >= 0 && sprites[i].y <= 65 && sprites[i].y >= 0)
            {
                for (int j = 0; j < sprites[i].pixels.GetLength(1); j++)
                {
                    for (int k = 0; k < sprites[i].pixels.GetLength(0); k++)
                    {
                        if (sprites[i].x + k <= 133 && sprites[i].x + k >= 0 && sprites[i].y + j <= 65 && sprites[i].y + j >= 0)
                        {
                            framedata[sprites[i].x + k, sprites[i].y + j] = sprites[i].pixels[k, j];
                        }
                    }
                }
            }
            
        }
    }
    public void parseFrame()
    {
        
        int pixelcount = 1;
        int k = 1;
        Chunk currentPixel = new Chunk();
        currentPixel.colour = framedata[0, 0];
        int previousline = 0;
        int addedlines = 0;
        chunkCount = 1;
        ConsoleColor previousPixel = framedata[0, 0];
        int[] endlines = new int[height];
        int endlinecount = 0;
        for (int i = 0; i < framedata.GetLength(1); i++)
        {
            for (int j = k; j < framedata.GetLength(0); j++)
            {
                if (j + 1 == framedata.GetLength(0))
                {
                    endlines[endlinecount] = pixelcount- previousline;
                    previousline = pixelcount;
                    endlinecount++;
                }
                if (framedata[j,i] != previousPixel)
                {
                    currentPixel.chunk = "";
                    
                    for (int l = 0; l < endlinecount; l++)
                    {
                        currentPixel.chunk += String.Concat(Enumerable.Repeat("  ", endlines[l]) + "\n");
                        addedlines += endlines[l];
                    }
                    currentPixel.chunk += String.Concat(Enumerable.Repeat("  ", pixelcount - addedlines));
                    frame[chunkCount] = currentPixel;
                    chunkCount++;
                    pixelcount = 1;
                    currentPixel = new Chunk();
                    currentPixel.colour = framedata[j,i];
                    previousPixel = framedata[j,i];
                    addedlines = 0;
                    endlinecount = 0;
                    previousline = 0;
                }
                else
                {
                    pixelcount++;
                    
                }
                
            }
            k = 0;
        }
        for (int l = 0; l < endlinecount; l++)
        {
            currentPixel.chunk += String.Concat(Enumerable.Repeat("  ", endlines[l]) + "\n");
            addedlines += endlines[l];
        }
        currentPixel.chunk += String.Concat(Enumerable.Repeat("  ", pixelcount - addedlines));
        frame[chunkCount] = currentPixel;
        chunkCount++;
    }
    public void printFrame()
    {
        
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < chunkCount; i++)
        {
            
            Console.BackgroundColor = frame[i].colour;
            Console.Write(frame[i].chunk);
        }
    }
}

