using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory.Token;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Token
{
    internal class OperatorTokenHandler : TokenHandler
    {
        private readonly OperatorTokenFactory operatorTokenFactory = new OperatorTokenFactory();
        internal override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == '&' || request == '|')
            {
                token = operatorTokenFactory.Create(request);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }

    }
}
