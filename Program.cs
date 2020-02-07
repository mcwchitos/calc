using System;
using System.Linq;
using NUnit;
using NUnit.Framework;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Tester();
            // t.allTests();
            while (true)
            {
                Console.WriteLine();
                var line = Console.ReadLine();
                line = new string((from c in line
                        where !char.IsWhiteSpace(c)
                        select c
                    ).ToArray());

                var parser = new Parser(line);
                var tree = parser.Parse();
                var result = tree.Calculate();
                Console.WriteLine(result);
            }
        }
    }
}