using System;
using System.Threading;
using System.Diagnostics;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        PixelEngine engine = new PixelEngine();
        ConsoleColor[,] player = new ConsoleColor[,]{ { ConsoleColor.Red } };
        engine.addSprite(player, 25, 25, false);
        Console.CursorVisible = false;
        long milli = 0;
        Stopwatch sw = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        ConsoleKeyInfo input = new ConsoleKeyInfo();
        int input2 = -1;
        bool quit = false;
        new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            //input = Console.ReadKey();
            while (input.Key != ConsoleKey.Q)
            {
                //input = Console.ReadKey();
                input2 = Console.Read();
            }
            quit = true;
        }).Start();
        new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            while (!quit)
            {
                switch (input.Key) {
                    case ConsoleKey.W:
                        engine.moveSprite(0, 0, -1);
                        input = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.A:
                        engine.moveSprite(0, -1, 0);
                        input = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.S:
                        engine.moveSprite(0, 0, 1);
                        input = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.D:
                        engine.moveSprite(0, 1, 0);
                        input = new ConsoleKeyInfo();
                        break;
                }
            }
        }).Start();
        while (!quit)
        {
            sw = new Stopwatch();
            sw2 = new Stopwatch();
            //engine.square();
            //Console.Clear();
            sw.Start();
            engine.writeToFrame();
            engine.parseFrame();
            engine.printFrame();
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            milli = sw.ElapsedMilliseconds;
            if (milli == 0)
            {
                milli = 0;
            }
            Console.Write(1000/milli);
            //Console.ReadLine();
        }
    }
}

