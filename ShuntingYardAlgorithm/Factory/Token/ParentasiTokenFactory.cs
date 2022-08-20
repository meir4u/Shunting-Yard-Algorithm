using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
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
            token.Type = (c == '(') ? EParentesi.ParentesiState.Open : EParentesi.ParentesiState.Close;
            return token;
        }
    }
}
