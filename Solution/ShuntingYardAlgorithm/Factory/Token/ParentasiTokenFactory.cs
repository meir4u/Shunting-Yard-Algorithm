using ShuntingYardAlgorithm.Base.Token;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Token
{
    internal class ParentasiTokenFactory
    {
        internal ParentasiTokenFactory()
        {

        }

        internal IToken Create(char c)
        {
            var token = new ParentesiToken();
            token.RawValue = c;
            token.Type = ParentasiTokenConfig.GetParentasiState(c.ToString());
            token.Precedence = ParentasiTokenConfig.GetPrecedence(token.Type);
            return token;
        }
    }
}
