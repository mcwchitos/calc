using System;
using System.Linq;
using NUnit.Framework;

namespace calc
{
    public class Tester
    {
        private readonly int _round;

        public Tester(int round)
        {
            _round = round;
        }

        public void allTests()
        {
            DivideByZeroExceptions();
            test1();
            test2();
            test3();
            Console.WriteLine("All tests have been passed");
        }
        
        private void DivideByZeroExceptions()
        {
            var line = "2.7 / 0";
            line = new string((from c in line
                    where !char.IsWhiteSpace(c)
                    select c
                ).ToArray());
            var parser = new Parser(line, _round);
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
            var parser = new Parser(line, _round);
            Assert.AreEqual(Math.Round(-2.7 * -2.7, 2), parser.Parse().Calculate());
            Console.WriteLine("Test 1 has been passed");
        }

        private void test2()
        {
            var line = "2a-b";
            line = new string((from c in line
                    where !char.IsWhiteSpace(c)
                    select c
                ).ToArray());
            var parser = new Parser(line, _round);
            Assert.AreEqual(null, parser.Parse());
            Console.WriteLine("Test 2 has been passed");
        }
        
        private void test3()
        {
            var line1 = "1/3";
            line1 = new string((from c in line1
                    where !char.IsWhiteSpace(c)
                    select c
                ).ToArray());
            var parser1 = new Parser(line1, _round);
            Assert.AreEqual(Math.Round(1.0/3.0, 2), parser1.Parse().Calculate());
            
            var line2 = "2/3";
            line2 = new string((from c in line2
                    where !char.IsWhiteSpace(c)
                    select c
                ).ToArray());
            var parser2 = new Parser(line2, _round);
            Assert.AreEqual(Math.Round(2.0/3.0, 2), parser2.Parse().Calculate());
            
            Console.WriteLine("Test 3 has been passed");
        }
    }
}