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
        internal override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == 't' || request == 'T')
            {
                token = BooleanTokenFactory.Create(EShYAlgorithm.BooleanType.Positive);
            }else if(request == 'f' || request == 'F')
            {
                token = BooleanTokenFactory.Create(EShYAlgorithm.BooleanType.Negative);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }

        
    }
}
