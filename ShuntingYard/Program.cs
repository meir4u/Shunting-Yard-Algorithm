using ShuntingYardAlgorithm;
using System;

namespace ShuntingYard
{
    class Program
    {
        static void Main(string[] args)
        {
            string raw = "(T&F|T)&(F&T|F)";
            var data = new SYAlgorithm(raw).create();

            Console.WriteLine(data.ToString());
            Console.WriteLine("Hello World!");
        }
    }
}
