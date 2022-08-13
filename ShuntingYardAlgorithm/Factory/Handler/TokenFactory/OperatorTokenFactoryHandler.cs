using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.TokenFactory
{
    internal class OperatorTokenFactoryHandler : TokenFactoryHandler
    {
        internal override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == '&' || request == '|')
            {
                token = createOperatorToken(request);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }

        private IToken createOperatorToken(char c)
        {
            var data = new OperatorToken();
            data.RawValue = c;
            data.Type = (c == '&') ? EShYAlgorithm.OperatorType.And : EShYAlgorithm.OperatorType.Or;
            data.Precedence = (int)data.Type;
            return data;
        }
    }
}
