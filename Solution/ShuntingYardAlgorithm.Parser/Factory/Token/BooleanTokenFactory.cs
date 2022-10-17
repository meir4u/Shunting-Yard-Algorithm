using ShuntingYardAlgorithm.Base.Enum;
using ShuntingYardAlgorithm.Base.Token;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Base.Exceptions.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Factory.Token
{
    public class BooleanTokenFactory
    {
        public BooleanTokenFactory()
        {

        }

        public IToken Create(char c)
        {
            var token = create(c);
            return token;
        }

        public IToken Create(string c)
        {
            var token = create(c[0]);
            return token;
        }

        public IToken Create(EOperator.BooleanType type)
        {
            var token = create(type);
            return token;
        }

        protected IToken create(EOperator.BooleanType type)
        {
            var data = new BooleanToken();
            data.RawValue = EOperator.BooleanType.Positive == type ? 't' : 'f';
            data.Type = EData.Type.Boolean;
            data.Value = type == EOperator.BooleanType.Positive;
            return data;
        }

        protected IToken create(char c)
        {
            IToken token;
            switch (c)
            {
                case 'T':
                case 't':
                    token = create(EOperator.BooleanType.Positive);
                    break;
                case 'F':
                case 'f':
                    token = create(EOperator.BooleanType.Negative);
                    break;
                default:
                    throw new TokenNotSupportedException();
            }
            return token;
        }

    }
}
