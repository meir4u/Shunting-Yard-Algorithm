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

        internal static IToken Create(EShYAlgorithm.BooleanType type)
        {
            lock (instance)
            {
                var token = instance.create(type);
                return token;
            }
        }

        protected IToken create(EShYAlgorithm.BooleanType type)
        {
            var data = new BooleanToken();
            data.RawValue = EShYAlgorithm.BooleanType.Positive == type ? 't' : 'f';
            data.Type = type;
            data.Value = data.Type == EShYAlgorithm.BooleanType.Positive;
            return data;
        }

        protected IToken create(char c)
        {
            IToken token;
            switch (c)
            {
                case 'T':
                case 't':
                    token = create(EShYAlgorithm.BooleanType.Positive);
                    break;
                case 'F':
                case 'f':
                    token = create(EShYAlgorithm.BooleanType.Negative);
                    break;
                default:
                    throw new Exception("Token not supported!");
            }
            return token;
        }

    }
}
