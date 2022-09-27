using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Factory.Handler.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class TokenAbstractFactory
    {
        private readonly TokenHandler tokenHandler;

        internal TokenAbstractFactory()
        {
            tokenHandler = getHandler();
        }

        public IToken Create(char c)
        {
            IToken result;

            result = tokenHandler.HandleReqeust(c);

            return result;
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
