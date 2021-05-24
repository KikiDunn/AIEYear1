using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	public class Colour
	{
		public uint colour = 0;

		public Colour(byte red, byte green, byte blue, byte alpha)
		{
			//r  g  b  a
			colour = (uint)((red << 24) + (green << 16) + (blue << 8) + alpha);
		}
		public Colour()
		{

		}
		public void SetRed(byte red)
		{
			//RGBA
			colour = colour & 0x00FFFFFF;
			colour = colour | (uint)(red << 24);
		}

		public byte GetRed()
		{
			return (byte)(colour >> 24);
		}
		public void SetGreen(byte green)
		{
			//RGBA
			colour = colour & 0xFF00FFFF;
			colour = colour | (uint)(green << 16);
		}

		public byte GetGreen()
		{
			return (byte)(colour >> 16);
		}
		public void SetBlue(byte blue)
		{
			//RGBA
			colour = colour & 0xFFFF00FF;
			colour = colour | (uint)(blue << 8);
		}

		public byte GetBlue()
		{
			return (byte)(colour >> 8);
		}
		public void SetAlpha(byte alpha)
		{
			//RGBA
			colour = colour & 0xFFFFFF00;
			colour = colour | alpha;
		}

		public byte GetAlpha()
		{
			return (byte)(colour & 0x000000FF);
		}
	}
}