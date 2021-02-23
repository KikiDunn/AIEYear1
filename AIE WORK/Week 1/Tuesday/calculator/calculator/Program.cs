using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter first number:");
                string firstNumber = Console.ReadLine();
                double leftNumber = int.Parse(firstNumber);

                Console.WriteLine("Enter symbol");
                string symbol = Console.ReadLine();

                Console.WriteLine("Enter second number");
                string secondNumber = Console.ReadLine();
                double rightNumber = int.Parse(secondNumber);

                double result = DoMath(leftNumber, symbol, rightNumber);
                Console.WriteLine("Answer:");
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
        static double DoMath(double lhs, string symbol, double rhs)
        {
            double answer = 0;
            if(symbol == "+")
            {
                answer = lhs + rhs;
            }
            if (symbol == "-")
            {
                answer = lhs - rhs;
            }

            if (symbol == "/")
            {
                if (rhs == 0)
                {
                    answer = 0;
                }
                else
                {
                    answer = lhs / rhs;
                }
            }
            if (symbol == "^")
            {
                answer = Math.Pow(lhs, rhs);
            }
            if (symbol == "%")
            {
                answer = lhs % rhs;
            }
            if (symbol == "*")
            {
                answer = lhs * rhs;
            }
            

            return answer;
        }
    }
}
