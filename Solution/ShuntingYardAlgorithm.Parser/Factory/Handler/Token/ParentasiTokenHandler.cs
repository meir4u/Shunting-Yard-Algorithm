using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Parser.Factory.Token;
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
                token = parentasiTokenFactory.Create(request);
            }
            else
            {
                token = nextHandle(request);
            }
            return token;
        }
    }
}
