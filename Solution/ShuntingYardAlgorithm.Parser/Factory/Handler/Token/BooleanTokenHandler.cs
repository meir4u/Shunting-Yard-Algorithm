using ShuntingYardAlgorithm.Base.Enum;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Parser.Factory.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory.Handler.Token
{
    internal class BooleanTokenHandler : TokenHandler
    {
        private readonly BooleanTokenFactory booleanTokenFactory = new BooleanTokenFactory();
        public override IToken HandleReqeust(char request)
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
