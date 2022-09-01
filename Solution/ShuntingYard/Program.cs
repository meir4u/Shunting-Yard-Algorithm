using ShuntingYardAlgorithm;
using System;

namespace ShuntingYard
{
    class Program
    {
        static void Main(string[] args)
        {
            string raw3 = "T|(F&F)";
            string raw4 = "t&(t&t)&t";
            string raw = "(T&F|T)|(F&T|F)";
            string raw2 = "T&F&T&F|T&F&F&F|T|F&F|T&T|F";

            var shuntingYard = new SYAlgorithm();
            var data = shuntingYard.Calculate(raw4);
            //var data2 = SYAlgorithm.Calculate(raw2);

            Console.WriteLine(data.ToString());
            //Console.WriteLine(data2.ToString());

            Console.WriteLine("End!");
        }
    }
}
