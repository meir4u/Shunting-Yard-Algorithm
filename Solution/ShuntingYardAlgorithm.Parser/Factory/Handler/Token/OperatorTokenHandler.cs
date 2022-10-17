using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Parser.Factory.Token;
using ShuntingYardAlgorithm.Parser.Rule.Token.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory.Handler.Token
{
    public class OperatorTokenHandler : TokenHandler
    {
        private readonly OperatorTokenFactory operatorTokenFactory = new OperatorTokenFactory();
        public override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == '&' || request == '|')
            {
                token = operatorTokenFactory.Create(request.ToString());
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }

        public override IToken HandleReqeust(ITokenRuleResult request)
        {
            IToken token;
            if (request.Type == Base.Enum.EData.Type.Operator)
            {
                token = operatorTokenFactory.Create(request.rawToken);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }
    }
}
