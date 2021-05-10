using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedCSharpLinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums = from n in numbers
                            select strings[n];

            Console.WriteLine("Number strings:");
            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }

            var lowNums = from n in numbers
                          where n < 5
                          select strings[n];

            int[] numbersA = { 0, 2, 4, 5, 6 };
            int[] numbersB = { 1, 3, 5, };

            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { a, b };

            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs)
            {
                Console.WriteLine("{0} is less than {1}", pair.a, pair.b);
            }

            var first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:");

            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }

            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:");
            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }

            // Async,await,task ,Threading

            var demo = new AsyncAwaitDemo();
            demo.DoStuff();

            while (true)
            {
                Console.WriteLine("Doing Stuff on the Main Thread...................");
            }

        }
    }
    public class AsyncAwaitDemo
    {
        public async Task DoStuff()
        {
            await Task.Run(() =>
            {
                LongRunningOperation();
            });
        }

        private static async Task<string> LongRunningOperation()
        {
            int counter;

            for (counter = 0; counter < 5000; counter++)
            {
                Console.WriteLine(counter);
            }

            return "Counter = " + counter;
        }
    }
}

