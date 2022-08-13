using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Token
{
    internal class OperatorTokenFactory
    {
        private static Lazy<OperatorTokenFactory> lazy = new Lazy<OperatorTokenFactory>(() => new OperatorTokenFactory(), true);
        private static OperatorTokenFactory instance { get => lazy.Value; }

        private OperatorTokenFactory()
        {

        }

        internal static IToken Create(char c)
        {
            lock (instance)
            {
                var token = instance.create(c);
                return token;
            }
        }
        private IToken create(char c)
        {
            var data = new OperatorToken();
            data.RawValue = c;
            data.Type = (c == '&') ? EShYAlgorithm.OperatorType.And : EShYAlgorithm.OperatorType.Or;
            data.Precedence = (int)data.Type;
            return data;
        }
    }
}
