using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Parser.Factory.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory.Handler.Token
{
    public class OperatorTokenHandler : TokenHandler
    {
        private readonly OperatorTokenFactory operatorTokenFactory = new OperatorTokenFactory();
        public override IToken HandleReqeust(char request)
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
