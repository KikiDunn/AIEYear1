using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {

        Stopwatch stop1 = new Stopwatch();
        stop1.Start();
        Console.BackgroundColor = ConsoleColor.White;
        for (int i = 0; i < 32; i++)
        {
            Console.SetCursorPosition(i * 2, 0);
            Console.Write("  ");
            Console.SetCursorPosition(i * 2, 1);
            Console.Write("  "); 
            Console.SetCursorPosition(i * 2, 2);
            Console.Write("  "); 
            Console.SetCursorPosition(i * 2, 3);
            Console.Write("  "); 
            Console.SetCursorPosition(i * 2, 4);
            Console.Write("  ");
        }
        Console.ResetColor();
        stop1.Stop();
        Console.WriteLine(stop1.ElapsedMilliseconds);
        Console.ReadLine();
        string line = "";
        for(int i = 0; i < 32; i++)
        {
            line += "  ";
        }
        stop1.Reset();
        stop1.Start();
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(line);
        Console.WriteLine(line);
        Console.WriteLine(line);
        Console.WriteLine(line);
        Console.WriteLine(line);
        Console.WriteLine(line);
        Console.ResetColor();
        stop1.Stop();
        Console.WriteLine(stop1.ElapsedMilliseconds);
        Console.ReadLine();
    }
    
}
