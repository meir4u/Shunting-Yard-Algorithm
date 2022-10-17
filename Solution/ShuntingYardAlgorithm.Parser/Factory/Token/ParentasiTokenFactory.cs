using ShuntingYardAlgorithm.Base.Token;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Base.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory.Token
{
    public class ParentasiTokenFactory
    {
        public ParentasiTokenFactory()
        {

        }

        public IToken Create(string c)
        {
            var token = new ParentesiToken();
            token.RawValue = c;
            token.Type = ParentasiTokenConfig.GetParentasiState(c.ToString());
            token.Precedence = ParentasiTokenConfig.GetPrecedence(token.Type);
            return token;
        }
    }
}
