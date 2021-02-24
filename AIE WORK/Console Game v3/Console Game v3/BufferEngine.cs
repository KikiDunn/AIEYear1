using System;
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
	short width = 960;
	short height = 202;
	ConsoleColor[,] framedata;
	List<Sprite> sprites = new List<Sprite>();
	int spriteCount = 0;
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
}
	

