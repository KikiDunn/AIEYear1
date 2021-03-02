using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
	
	static void Main(string[] args)
	{
		Console.CursorVisible = false;
		BufferEngine engine = new BufferEngine();
		Background background = new Background(engine);
		ImageLoader imageLoader = new ImageLoader();
		Player player = new Player(engine, imageLoader.getSprite(0));
		Input input = new Input(player);
		while (!input.isQuit())
		{
			engine.loadFrame();
			engine.print();
		}
	}
}

