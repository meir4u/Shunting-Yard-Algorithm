using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Parser.Factory.Token;
using ShuntingYardAlgorithm.Parser.Rule.Token.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory.Handler.Token
{
    public class ParentasiTokenHandler : TokenHandler
    {
        private readonly ParentasiTokenFactory parentasiTokenFactory = new ParentasiTokenFactory();
        public override IToken HandleReqeust(char request)
        {
            IToken token;
            if (request == '(' || request == ')')
            {
                token = parentasiTokenFactory.Create(request.ToString());
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
            if (request.Type == Base.Enum.EData.Type.Parentasi)
            {
                token = parentasiTokenFactory.Create(request.rawToken);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }
    }
}
