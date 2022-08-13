using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.TokenFactory
{
    internal class BoolianTokenFactoryHandler : TokenFactoryHandler
    {
        internal override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == 't' || request == 'T')
            {
                token = createBoolianToken(EShYAlgorithm.BoolianType.Positive);
            }else if(request == 'f' || request == 'F')
            {
                token = createBoolianToken(EShYAlgorithm.BoolianType.Negative);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }

        private IToken createBoolianToken(EShYAlgorithm.BoolianType type)
        {
            var data = new BoolianToken();
            data.RawValue = EShYAlgorithm.BoolianType.Positive == type ? 't' : 'f';
            data.Type = type;
            data.Value = data.Type == EShYAlgorithm.BoolianType.Positive;
            return data;
        }
    }
}
