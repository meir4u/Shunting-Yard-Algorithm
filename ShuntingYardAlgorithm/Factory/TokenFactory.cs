using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory.Handler.TokenFactory;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class TokenFactory
    {
        private static Lazy<TokenFactory> lazy = new Lazy<TokenFactory>(()=>new TokenFactory(), true);
        private static TokenFactory instance { get => lazy.Value; }

        private TokenFactory()
        {

        }

        public static IToken Create(char c)
        {
            lock (instance)
            {
                var result = instance.create(c);
                return result;
            }
        }

        private IToken create(char c)
        {
            IToken data;

            var handler = getHandler();

            data = handler.HandleReqeust(c);

            return data;
        }

        private TokenFactoryHandler getHandler()
        {
            TokenFactoryHandler h1 = new OperatorTokenFactoryHandler();
            TokenFactoryHandler h2 = new ParentasiTokenFactoryHandler();
            TokenFactoryHandler h3 = new BoolianTokenFactoryHandler();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            return h1;
        }

    }
}
