using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    internal class TokenFactory
    {
        private static Lazy<TokenFactory> lazy = new Lazy<TokenFactory>(()=>new TokenFactory());
        internal static TokenFactory Current { get => lazy.Value; }
        private TokenFactory()
        {

        }

        internal IData Create(char c)
        {
            IData data;
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

        private IData createParentesiToken(char c)
        {
            var data = new ParentesiData();
            data.RawValue = c;
            data.Type = (c == '(') ? EShYAlgorithm.ParentesiType.Open : EShYAlgorithm.ParentesiType.Close;
            return data;
        }

        private IData createDataToken(EShYAlgorithm.BoolianType type)
        {
            var data = new BoolianData();
            data.RawValue = EShYAlgorithm.BoolianType.Positive == type ? 't' : 'f';
            data.Type = type;
            data.Value = data.Type == EShYAlgorithm.BoolianType.Positive;
            return data;
        }

        private IData createOperatorToken(char c)
        {
            var data = new OperatorData();
            data.RawValue = c;
            data.Type = (c == '&') ? EShYAlgorithm.OperatorType.And : EShYAlgorithm.OperatorType.Or;
            data.Precedence = (int)data.Type;
            return data;
        }
    }
}
