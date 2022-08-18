using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Token
{
    internal class ParentasiTokenFactory
    {
        private static Lazy<ParentasiTokenFactory> lazy = new Lazy<ParentasiTokenFactory>(() => new ParentasiTokenFactory(), true);
        private static ParentasiTokenFactory instance { get => lazy.Value; }

        private ParentasiTokenFactory()
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
            var data = new ParentesiToken();
            data.RawValue = c;
            data.Type = (c == '(') ? EParentesi.ParentesiState.Open : EParentesi.ParentesiState.Close;
            return data;
        }
    }
}
