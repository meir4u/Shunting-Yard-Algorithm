using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory.Token;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Token
{
    internal class BooleanTokenHandler : TokenHandler
    {
        private readonly BooleanTokenFactory booleanTokenFactory = new BooleanTokenFactory();
        internal override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == 't' || request == 'T')
            {
                token = booleanTokenFactory.Create(EOperator.BooleanType.Positive);
            }
            else if(request == 'f' || request == 'F')
            {
                token = booleanTokenFactory.Create(EOperator.BooleanType.Negative);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }

        
    }
}
