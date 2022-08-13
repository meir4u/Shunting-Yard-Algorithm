using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class SYAlgorithm
    {
        private static Lazy<SYAlgorithm> lazy = new Lazy<SYAlgorithm>(()=>new SYAlgorithm(), true);

        private SYAlgorithm()
        {

        }

        public static bool Calculate(string rawData)
        {
            bool result = lazy.Value.getResult(rawData);
            return result;
        }

        private bool getResult(string rawData)
        {
            Queue<IToken> infix = InfixFactory.create(rawData);
            Queue<IToken> postfix = PostfixFactory.Create(infix);
            bool calc = CalculatorFactory.Calculate(postfix);

            return calc;
        } 

    }
}
