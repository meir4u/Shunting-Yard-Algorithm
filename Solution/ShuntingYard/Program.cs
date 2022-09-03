using ShuntingYardAlgorithm;
using System;
using System.Collections.Generic;

namespace ShuntingYard
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> raw = new List<string>();

            raw.Add("t&(t&t)|t|t&(t&f)|t");
            raw.Add("f&(f|f)&f&f&(f|f)&t");
            raw.Add("t&(t|t)|f|t&(t|t)|t");
            raw.Add("f|(f&t)|f|f|(f&f)|f");


            var shuntingYard = new SYAlgorithm();
            bool data = false;
            int i = 0;
            foreach (var item in raw)
            {
                data = shuntingYard.Calculate(item);
                i++;
            }
            //var data2 = SYAlgorithm.Calculate(raw2);

            Console.WriteLine(data.ToString());
            //Console.WriteLine(data2.ToString());

            Console.WriteLine("End!");
        }
    }
}
