using System;
using System.Linq;
using NUnit.Framework;

namespace calc
{
    public class Tester
    {
        public Tester(){}

        public void allTests()
        {
            DivideByZeroExceptions();
            test1();
            test2();
            Console.WriteLine("All tests have been passed");
        }
        
        private void DivideByZeroExceptions()
        {
            var line = "2.7 / 0";
            line = new string((from c in line
                    where !char.IsWhiteSpace(c)
                    select c
                ).ToArray());
            var parser = new Parser(line);
            Assert.AreEqual(double.PositiveInfinity, parser.Parse().Calculate());
            Console.WriteLine("Divide by zero test has been passed");
        }

        private void test1()
        {
            var line = "-2.7 * -2.7";
            line = new string((from c in line
                    where !char.IsWhiteSpace(c)
                    select c
                ).ToArray());
            var parser = new Parser(line);
            Assert.AreEqual(Math.Round(-2.7 * -2.7, 2), parser.Parse().Calculate());
            Console.WriteLine("Test 1 has been passed");
        }

        private void test2()
        {
            Console.WriteLine("Test 2 has been passed");
        }
    }
}