using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.TokenFactory
{
    internal abstract class TokenFactoryHandler
    {
        protected TokenFactoryHandler successor = null;
        internal void SetSuccessor(TokenFactoryHandler successor)
        {
            this.successor = successor;
        }

        internal abstract IToken HandleReqeust(char request);

        protected IToken nextHandle(char request)
        {
            IToken token;
            if (successor != null)
            {
                token = successor.HandleReqeust(request);
            }
            else
            {
                throw new Exception($"Not Supported Token:'{request}'");
            }

            return token;
        }
    }
}
