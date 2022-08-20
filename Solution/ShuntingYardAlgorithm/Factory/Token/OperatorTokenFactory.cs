using ShuntingYardAlgorithm.Config;
using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Token
{
    internal class OperatorTokenFactory
    {
        internal OperatorTokenFactory()
        {

        }

        internal IToken Create(char c)
        {
            var token = new OperatorToken();
            token.RawValue = c;
            token.Type = OperatorTokenConfig.GetOperatorType(c.ToString());
            token.Precedence = OperatorTokenConfig.GetPrecedence(token.Type);
            return token;
        }
    }
}
