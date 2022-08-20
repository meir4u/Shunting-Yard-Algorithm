using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory.Token;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Token
{
    internal class ParentasiTokenHandler : TokenHandler
    {
        private readonly ParentasiTokenFactory parentasiTokenFactory = new ParentasiTokenFactory();
        internal override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == '(' || request == ')')
            {
                token = parentasiTokenFactory.Create(request);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }
    }
}
