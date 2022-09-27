using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Parser.Factory.Handler.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory
{
    public class TokenAbstractFactory
    {
        private readonly TokenHandler tokenHandler;

        public TokenAbstractFactory()
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
