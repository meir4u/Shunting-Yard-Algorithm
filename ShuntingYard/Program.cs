using ShuntingYardAlgorithm;
using System;

namespace ShuntingYard
{
    class Program
    {
        static void Main(string[] args)
        {
            string raw = "(T&F|T)|(F&T|F)";
            string raw2 = "T&F&T&F|T&F&F&F|T|F&F|T&T|F";

            var data = SYAlgorithm.Calculate(raw);
            var data2 = SYAlgorithm.Calculate(raw2);

            Console.WriteLine(data.ToString());
            Console.WriteLine(data2.ToString());

            Console.WriteLine("End!");
        }
    }
}
