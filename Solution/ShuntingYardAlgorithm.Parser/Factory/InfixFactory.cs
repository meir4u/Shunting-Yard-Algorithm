using ShuntingYardAlgorithm.Base.Token.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory
{
    public class InfixFactory
    {
        private readonly TokenAbstractFactory tokenAbstractFactory = new TokenAbstractFactory();
        public InfixFactory()
        {

        }
        public Queue<IToken> Create(string rawData)
        {
            var result = createInfix(rawData);
            return result;
        } 
        private Queue<IToken> createInfix(string rawData)
        {
            int length = rawData.Length;
            var infix = new Queue<IToken>();

            for (int i = 0; i < length; i++)
            {
                IToken data = tokenAbstractFactory.Create(rawData[i]);
                infix.Enqueue(data);
            }

            return infix;
        }
    }
}
