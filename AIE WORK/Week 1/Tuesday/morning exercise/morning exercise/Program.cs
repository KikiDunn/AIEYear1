using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    
    static void Main(string[] args)
    {
        ConsoleKeyInfo input;
        Random random = new Random();
        int[,] player = new int[1024,2];
        int[,] previousSnake = new int[1024,2];
        
        int snakeLength = 3;
        int[] apple = { 20, 20 };
        bool lose = false;
        player[0,0] = 15;
        player[0,1] = 15;
        Console.CursorVisible = false;
        DrawBox();
        
        DrawFrame(player, snakeLength, apple);
        input = Console.ReadKey(true);
        Thread thread = new Thread(() =>
        {
            while(input.Key != ConsoleKey.Q)
            {
                input = Console.ReadKey(true);
            }
            lose = true;
        });
        thread.IsBackground = true;
        thread.Start();
        while (!lose)
        {
            for (int i = 0; i <= snakeLength; i++)
            {
                previousSnake[i + 1,0] = player[i,0];
                previousSnake[i + 1, 1] = player[i, 1];
            }
            
            ClearPixel(player[snakeLength -1, 0], player[snakeLength -1, 1]);
            
            DrawFrame(player, snakeLength, apple);
            System.Threading.Thread.Sleep(100);
            switch (input.Key)
            {
                case ConsoleKey.W:
                    player[0,1] -= 1;
                    break;
                case ConsoleKey.A:
                    player[0,0] -= 1;
                    break;
                case ConsoleKey.S:
                    player[0,1] += 1;
                    break;
                case ConsoleKey.D:
                    player[0,0] += 1;
                    break;
            }
            for (int i = 1; i < snakeLength; i++)
            {
                player[i,0] = previousSnake[i,0];
                player[i, 1] = previousSnake[i, 1];
                if (player[0,1] == player[i,1] && player[0, 0] == player[i, 0])
                {
                    lose = true;
                }
            }
            if (player[0, 1] == apple[1] && player[0, 0] == apple[0])
            {
                ClearPixel(apple[0], apple[1]);
                snakeLength++;
                apple[0] = random.Next(1, 31);
                apple[1] = random.Next(1, 31);

            }
            
        }
        
    }
    static void DrawFrame(int[,] player, int length, int[] apple)
    {
        for (int i = 0; i < length; i++)
        {
            Console.SetCursorPosition(player[i,0]*2, player[i,1]);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
            Console.ResetColor();
        }
        Console.SetCursorPosition(apple[0]*2, apple[1]);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("  ");
        Console.ResetColor();
    }
    static void DrawBox()
    {
        Console.BackgroundColor = ConsoleColor.White;
        for (int i = 0; i < 32; i++)
        {
            Console.SetCursorPosition(i*2, 0);
            Console.Write("  ");
            Console.SetCursorPosition(i*2, 31);
            Console.Write("  ");
            Console.SetCursorPosition(0, i);
            Console.Write("  ");
            Console.SetCursorPosition(62, i);
            Console.Write("  ");
        }
        Console.ResetColor();
    }
    static void ClearPixel(int x, int y)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(x*2,y);
        Console.Write("  ");
    }
}


