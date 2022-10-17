using ShuntingYardAlgorithm.Base.Token;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Base.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory.Token
{
    public class OperatorTokenFactory
    {
        public OperatorTokenFactory()
        {

        }

        public IToken Create(string c)
        {
            var token = new OperatorToken();
            token.RawValue = c;
            token.Type = OperatorTokenConfig.GetOperatorType(c);
            token.Precedence = OperatorTokenConfig.GetPrecedence(token.Type);
            token.Associative = OperatorTokenConfig.GetAssociative(token.Type);
            return token;
        }
    }
}
