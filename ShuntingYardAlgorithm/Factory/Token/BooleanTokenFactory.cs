using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Token
{
    internal class BooleanTokenFactory
    {
        private static Lazy<BooleanTokenFactory> lazy = new Lazy<BooleanTokenFactory>(() => new BooleanTokenFactory(), true);
        private static BooleanTokenFactory instance { get => lazy.Value; }

        private BooleanTokenFactory()
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

        internal static IToken Create(EOperator.BooleanType type)
        {
            lock (instance)
            {
                var token = instance.create(type);
                return token;
            }
        }

        protected IToken create(EOperator.BooleanType type)
        {
            var data = new BooleanToken();
            data.RawValue = EOperator.BooleanType.Positive == type ? 't' : 'f';
            data.Type = type;
            data.Value = data.Type == EOperator.BooleanType.Positive;
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
                    throw new System.Exception("Token not supported!");
            }
            return token;
        }

    }
}
