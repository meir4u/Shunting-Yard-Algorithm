using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.TokenFactory
{
    internal class ParentasiTokenFactoryHandler : TokenFactoryHandler
    {
        internal override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == '(' || request == ')')
            {
                token = createParentesiToken(request);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }

        private IToken createParentesiToken(char c)
        {
            var data = new ParentesiToken();
            data.RawValue = c;
            data.Type = (c == '(') ? EShYAlgorithm.ParentesiType.Open : EShYAlgorithm.ParentesiType.Close;
            return data;
        }
    }
}
