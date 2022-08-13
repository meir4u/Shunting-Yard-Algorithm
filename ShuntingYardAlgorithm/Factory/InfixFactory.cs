using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class InfixFactory
    {
        private static Lazy<InfixFactory> lazy = new Lazy<InfixFactory>(()=>new InfixFactory(), true);
        private static InfixFactory instance { get => lazy.Value; }

        private InfixFactory()
        {

        }
        internal static Queue<IToken> create(string rawData)
        {
            lock(instance)
            {
                var result = instance.createInfix(rawData);
                return result;
            }
        } 
        private Queue<IToken> createInfix(string rawData)
        {
            int length = rawData.Length;
            var infix = new Queue<IToken>();

            for (int i = 0; i < length; i++)
            {
                IToken data = TokenFactory.Create(rawData[i]);
                infix.Enqueue(data);
            }

            return infix;
        }
    }
}
