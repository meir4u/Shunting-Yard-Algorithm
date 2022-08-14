using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory.Handler.Token;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class TokenAbstractFactory
    {
        private static Lazy<TokenAbstractFactory> lazy = new Lazy<TokenAbstractFactory>(()=>new TokenAbstractFactory(), true);
        private static TokenAbstractFactory instance { get => lazy.Value; }

        private TokenAbstractFactory()
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

        private TokenHandler getHandler()
        {
            TokenHandler h1 = new OperatorTokenHandler();
            TokenHandler h2 = new ParentasiTokenHandler();
            TokenHandler h3 = new BooleanTokenHandler();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            return h1;
        }

    }
}
