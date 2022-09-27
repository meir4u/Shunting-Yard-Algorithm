using ShuntingYardAlgorithm.Factory;
using System;
using System.Collections.Generic;
using System.Text;
using ShuntingYardAlgorithm.Extension;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Parser.Factory;

namespace ShuntingYardAlgorithm
{
    public class SYAlgorithm
    {
        private readonly InfixFactory infixFactory = new InfixFactory();
        private readonly PostfixFactory postfixFactory = new PostfixFactory();
        private readonly CalculatorFactory calculatorFactory = new CalculatorFactory();

        public SYAlgorithm()
        {

        }

        public bool Calculate(string rawData)
        {
            bool result = getResult(rawData);
            return result;
        }

        private bool getResult(string rawData)
        {
            Queue<IToken> infix = infixFactory.Create(rawData);
            Queue<IToken> postfix = postfixFactory.Create(infix);
            bool calc = (bool)calculatorFactory.Calculate(postfix);

            return calc;
        } 

    }
}
