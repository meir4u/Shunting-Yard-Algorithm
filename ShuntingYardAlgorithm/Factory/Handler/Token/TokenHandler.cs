using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Token
{
    internal abstract class TokenHandler
    {
        protected TokenHandler successor = null;
        internal void SetSuccessor(TokenHandler successor)
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
