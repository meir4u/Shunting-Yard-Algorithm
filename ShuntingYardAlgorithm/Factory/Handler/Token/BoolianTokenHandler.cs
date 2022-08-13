using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory.Token;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Token
{
    internal class BoolianTokenHandler : TokenHandler
    {
        internal override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == 't' || request == 'T')
            {
                token = BoolianTokenFactory.Create(EShYAlgorithm.BoolianType.Positive);
            }else if(request == 'f' || request == 'F')
            {
                token = BoolianTokenFactory.Create(EShYAlgorithm.BoolianType.Negative);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }

        
    }
}
