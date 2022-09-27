﻿using ShuntingYardAlgorithm.Base.Enum;
using ShuntingYardAlgorithm.Base.Token;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Exceptions.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Token
{
    internal class BooleanTokenFactory
    {
        internal BooleanTokenFactory()
        {

        }

        internal IToken Create(char c)
        {
            var token = create(c);
            return token;
        }

        internal IToken Create(EOperator.BooleanType type)
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
