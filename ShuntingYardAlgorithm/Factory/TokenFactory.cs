using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class TokenFactory
    {
        private static Lazy<TokenFactory> lazy = new Lazy<TokenFactory>(()=>new TokenFactory(), true);
        private TokenFactory()
        {

        }

        public static IToken Create(char c)
        {
            var result = lazy.Value.create(c);
            return result;
        }

        private IToken create(char c)
        {
            IToken data;
            switch (c)
            {
                case '&':
                case '|':
                    data = createOperatorToken(c);
                    break;
                case '(':
                case ')':
                    data = createParentesiToken(c);
                    break;
                case 'T':
                case 't':
                    data = createDataToken(EShYAlgorithm.BoolianType.Positive);
                    break;
                case 'F':
                case 'f':
                    data = createDataToken(EShYAlgorithm.BoolianType.Negative);
                    break;
                default:
                    throw new Exception($"Not Supported Token:'{c}'");
            }

            return data;
        }

        private IToken createParentesiToken(char c)
        {
            var data = new ParentesiToken();
            data.RawValue = c;
            data.Type = (c == '(') ? EShYAlgorithm.ParentesiType.Open : EShYAlgorithm.ParentesiType.Close;
            return data;
        }

        private IToken createDataToken(EShYAlgorithm.BoolianType type)
        {
            var data = new BoolianToken();
            data.RawValue = EShYAlgorithm.BoolianType.Positive == type ? 't' : 'f';
            data.Type = type;
            data.Value = data.Type == EShYAlgorithm.BoolianType.Positive;
            return data;
        }

        private IToken createOperatorToken(char c)
        {
            var data = new OperatorToken();
            data.RawValue = c;
            data.Type = (c == '&') ? EShYAlgorithm.OperatorType.And : EShYAlgorithm.OperatorType.Or;
            data.Precedence = (int)data.Type;
            return data;
        }
    }
}
