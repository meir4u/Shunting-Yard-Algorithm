using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Base.Exceptions.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory.Handler.Token
{
    public abstract class TokenHandler
    {
        protected TokenHandler successor = null;
        internal void SetSuccessor(TokenHandler successor)
        {
            this.successor = successor;
        }

        public abstract IToken HandleReqeust(char request);

        protected IToken nextHandle(char request)
        {
            IToken token;
            if (successor != null)
            {
                token = successor.HandleReqeust(request);
            }
            else
            {
                throw new TokenNotSupportedException($"Not Supported Token:'{request}'");
            }

            return token;
        }
    }
}
