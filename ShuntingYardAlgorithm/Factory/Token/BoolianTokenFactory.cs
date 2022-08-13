using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Token
{
    internal class BoolianTokenFactory
    {
        private static Lazy<BoolianTokenFactory> lazy = new Lazy<BoolianTokenFactory>(() => new BoolianTokenFactory(), true);
        private static BoolianTokenFactory instance { get => lazy.Value; }

        private BoolianTokenFactory()
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

        internal static IToken Create(EShYAlgorithm.BoolianType type)
        {
            lock (instance)
            {
                var token = instance.create(type);
                return token;
            }
        }

        protected IToken create(EShYAlgorithm.BoolianType type)
        {
            var data = new BoolianToken();
            data.RawValue = EShYAlgorithm.BoolianType.Positive == type ? 't' : 'f';
            data.Type = type;
            data.Value = data.Type == EShYAlgorithm.BoolianType.Positive;
            return data;
        }

        protected IToken create(char c)
        {
            IToken token;
            switch (c)
            {
                case 'T':
                case 't':
                    token = create(EShYAlgorithm.BoolianType.Positive);
                    break;
                case 'F':
                case 'f':
                    token = create(EShYAlgorithm.BoolianType.Negative);
                    break;
                default:
                    throw new Exception("Token not supported!");
            }
            return token;
        }

    }
}
