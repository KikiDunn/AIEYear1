using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Program
    {
        static void Main(string[] args)
        {
			//creates the game object
            Game game = new Game();
			//creates the window and sets screen size
            InitWindow(1020, 580, "program");
			//ToggleFullscreen();
            game.Init();

            while (!WindowShouldClose())
            {
				//updates and draws the game
                game.Update();
                game.Draw();
            }

            game.Shutdown();

            CloseWindow();
        }
    }
}
