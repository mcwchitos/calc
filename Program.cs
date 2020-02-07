using System;
using System.Linq;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Tester(2);
            t.allTests();
            while (true)
            {
                Console.WriteLine();
                var line = Console.ReadLine();
                line = new string((from c in line
                        where !char.IsWhiteSpace(c)
                        select c
                    ).ToArray());

                var parser = new Parser(line, 2);
                var tree = parser.Parse();
                if (tree == null)
                {
                    Console.WriteLine("incorrect input try again");
                    continue;
                }

                var result = tree.Calculate();
                Console.SetCursorPosition(Console.CursorSize, Console.CursorTop - 1);
                
                Console.Write(" = {0}",result);
            }
        }
    }
}