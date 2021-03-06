﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Threading;

class BufferEngine
{
	short width = (short)Console.BufferWidth;
	short height = (short)Console.BufferHeight;
	ConsoleColor[,] framedata;
	List<Sprite> sprites = new List<Sprite>();
	List<Particle> particles = new List<Particle>();
	int spriteCount = 0;
	int particlescount = 0;
	public BufferEngine()
	{
		
		framedata = new ConsoleColor[width, height];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				framedata[x, y] = ConsoleColor.Red;
			}
		}
	}
	#region some code shit idk
	[DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
	static extern SafeFileHandle CreateFile(
		string fileName,
		[MarshalAs(UnmanagedType.U4)] uint fileAccess,
		[MarshalAs(UnmanagedType.U4)] uint fileShare,
		IntPtr securityAttributes,
		[MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
		[MarshalAs(UnmanagedType.U4)] int flags,
		IntPtr template);

	[DllImport("kernel32.dll", SetLastError = true)]
	static extern bool WriteConsoleOutput(
	  SafeFileHandle hConsoleOutput,
	  CharInfo[] lpBuffer,
	  Coord dwBufferSize,
	  Coord dwBufferCoord,
	  ref SmallRect lpWriteRegion);

	[StructLayout(LayoutKind.Sequential)]
	public struct Coord
	{
		public short X;
		public short Y;

		public Coord(short X, short Y)
		{
			this.X = X;
			this.Y = Y;
		}
	};

	[StructLayout(LayoutKind.Explicit)]
	public struct CharUnion
	{
		[FieldOffset(0)] public char UnicodeChar;
		[FieldOffset(0)] public byte AsciiChar;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct CharInfo
	{
		[FieldOffset(0)] public CharUnion Char;
		[FieldOffset(2)] public short Attributes;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SmallRect
	{
		public short Left;
		public short Top;
		public short Right;
		public short Bottom;
	}
	#endregion some code shit idk
	public void print()
	{
		Console.WindowHeight = Console.LargestWindowHeight;
		Console.WindowWidth = Console.LargestWindowWidth;
		SafeFileHandle h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
		if (!h.IsInvalid)
		{
			CharInfo[] buf = new CharInfo[width * height];
			SmallRect rect = new SmallRect() { Left = 0, Top = 0, Right = width, Bottom = height };
			for (int y = 0; y < height; y++)
			{
				for(int x = 0; x < width; x++)
				{
					buf[x + y * width].Attributes = (short)(0 | ((int)framedata[x, y] << 4));
					buf[x + y * width].Char.UnicodeChar = ' ';
				}
			}
			
			WriteConsoleOutput(h, buf,
					  new Coord() { X = width, Y = height },
					  new Coord() { X = 0, Y = 0 },
					  ref rect);
		}
	}
	public int addSprite(int[,] pixels, int posX, int posY, bool hidden)
	{
		Sprite temp = new Sprite();
		temp.pixels = pixels;
		temp.hidden = hidden;
		temp.x = posX;
		temp.y = posY;
		sprites.Add(temp);
		spriteCount++;
		return spriteCount - 1;
	}
	public int addParticle(int[,] pixels, double[] posX, double[] posY, bool hidden, int particlesc)
	{
		Particle temp = new Particle();
		temp.pixels = pixels;
		temp.hidden = hidden;
		temp.x = posX;
		temp.y = posY;
		temp.particles = particlesc;
		particles.Add(temp);
		particlescount++;
		return particlescount - 1;
	}
	public void moveSprite(int ID, double posX, double posY)
	{
		sprites[ID].x += posX;
		sprites[ID].y += posY;
	}
	public void setPose(int ID, double[] posX, double[] posY, double[] angle)
	{
		particles[ID].x = posX;
		particles[ID].y = posY;
		particles[ID].angle = angle;
	}
	public void hideSprite(int ID, bool hidden)
	{
		sprites[ID].hidden = hidden;
	}
	public void hideParticle(int ID, bool hidden)
	{
		particles[ID].hidden = hidden;
	}
	public void loadFrame()
	{
		for(int i = 0; i < spriteCount; i++)
		{
			if(sprites[i].hidden == false)
			{
				if (sprites[i].angle != 0)
				{
					for (int y = 0; y < sprites[i].pixels.GetLength(1); y++)
					{
						for (int x = 0; x < sprites[i].pixels.GetLength(0); x++)
						{
							if (sprites[i].pixels[x, y] != -1)
							{
								float hy = (float)Math.Sqrt(Math.Pow(x / 2f - sprites[i].pixels.GetLength(0) / 4f, 2) + Math.Pow(y / 2f - sprites[i].pixels.GetLength(1) / 4f, 2));
								float oAngle = (float)Math.Atan2(y / 2f - (sprites[i].pixels.GetLength(1) / 4f), x / 2f - (sprites[i].pixels.GetLength(0) / 4f));
								float trigX = (float)Math.Cos(oAngle + sprites[i].angle * (Math.PI / 180f)) * hy;
								float trigY = (float)Math.Sin(oAngle + sprites[i].angle * (Math.PI / 180f)) * hy;
								float relx = (trigX + sprites[i].pixels.GetLength(0) / 4f);
								float rely = (trigY + (sprites[i].pixels.GetLength(1) / 4f)) / 2.5f;
								int inx = (int)Math.Round(sprites[i].x/2 + relx);
								int iny = (int)Math.Round(sprites[i].y/5 + rely);
								if (inx < framedata.GetLength(0) && inx >= 0 && iny < framedata.GetLength(1) && iny >= 0)
								{
									framedata[inx, iny] = (ConsoleColor)sprites[i].pixels[x, y];
								}
							}
						}
					}
				}
				else
				{
					for (int y = 2; y < sprites[i].pixels.GetLength(1); y += 5)
					{
						for (int x = 0; x < sprites[i].pixels.GetLength(0); x++)
						{
							if (sprites[i].pixels[x, y] != -1)
							{
								int inx = (int)Math.Round(sprites[i].x/2 + x / 2f);
								int iny = (int)Math.Round(sprites[i].y/5 + y / 5f);
								if (inx < framedata.GetLength(0) && inx >= 0 && iny < framedata.GetLength(1) && iny >= 0)
								{
									framedata[inx, iny] = (ConsoleColor)sprites[i].pixels[x, y];
								}
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < particlescount; i++)
		{
			if (particles[i].hidden == false)
			{
				for (int pcount = 0; pcount < 100; pcount++)
				{
					if (particles[i].angle[pcount] != 0)
					{
						for (int y = 0; y < particles[i].pixels.GetLength(1); y++)
						{
							for (int x = 0; x < particles[i].pixels.GetLength(0); x++)
							{
								if (particles[i].pixels[x, y] != -1)
								{
									float hy = (float)Math.Sqrt(Math.Pow(x / 2f - particles[i].pixels.GetLength(0) / 4f, 2) + Math.Pow(y / 2f - particles[i].pixels.GetLength(1) / 4f, 2));
									float oAngle = (float)Math.Atan2(y / 2f - (particles[i].pixels.GetLength(1) / 4f), x / 2f - (particles[i].pixels.GetLength(0) / 4f));
									float trigX = (float)Math.Cos(oAngle + particles[i].angle[pcount] * (Math.PI / 180f)) * hy;
									float trigY = (float)Math.Sin(oAngle + particles[i].angle[pcount] * (Math.PI / 180f)) * hy;
									float relx = (trigX + particles[i].pixels.GetLength(0) / 4f);
									float rely = (trigY + (particles[i].pixels.GetLength(1) / 4f)) / 2.5f;
									int inx = (int)Math.Round(particles[i].x[pcount] / 2 + relx);
									int iny = (int)Math.Round(particles[i].y[pcount] / 5 + rely);
									if (inx < framedata.GetLength(0) && inx >= 0 && iny < framedata.GetLength(1) && iny >= 0)
									{
										framedata[inx, iny] = (ConsoleColor)particles[i].pixels[x, y];
									}
								}
							}
						}
					}
					else
					{
						for (int y = 2; y < particles[i].pixels.GetLength(1); y += 5)
						{
							for (int x = 0; x < particles[i].pixels.GetLength(0); x++)
							{
								if (particles[i].pixels[x, y] != -1)
								{
									int inx = (int)Math.Round(particles[i].x[pcount] / 2 + x / 2f);
									int iny = (int)Math.Round(particles[i].y[pcount] / 5 + y / 5f);
									if (inx < framedata.GetLength(0) && inx >= 0 && iny < framedata.GetLength(1) && iny >= 0)
									{
										framedata[inx, iny] = (ConsoleColor)sprites[i].pixels[x, y];
									}
								}
							}
						}
					}
				}
			}
		}
	}
	public double getSpriteX(int ID)
	{
		return sprites[ID].x;
	}
	public double getSpriteY(int ID)
	{
		return sprites[ID].y;
	}
	public void rotateSprite(int ID, int degrees)
	{
		sprites[ID].angle += degrees;
	}
	public double getAngle(int ID)
	{
		return sprites[ID].angle;
	}
	public void changeFrame(int ID, int[,] pixels)
	{
		sprites[ID].pixels = pixels;
	}
	public double getParticleX(int ID, int index)
	{
		return particles[ID].x[index];
	}
	public double getParticleY(int ID, int index)
	{
		return particles[ID].y[index];
	}
	public double getParticleAngle(int ID, int index)
	{
		return particles[ID].angle[index];
	}
}
	

