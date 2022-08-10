using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    internal class DataFactory
    {
        private static Lazy<DataFactory> lazy = new Lazy<DataFactory>(()=>new DataFactory());
        internal static DataFactory Current { get => lazy.Value; }
        private DataFactory()
        {

        }

        internal IData Create(char c)
        {
            IData data;
            switch (c)
            {
                case '&':
                    data = createOperator(c, 10);
                    break;
                case '|':
                    data = createOperator(c, 2);
                    break;
                case '(':
                case ')':
                    data = createParentesi(c, 0);
                    break;
                default:
                    data = createData(c, 0);
                    break;


            }

            return data;
        }

        private IData createParentesi(char c, int value)
        {
            var data = new Data();
            data.Precedence = value;
            data.RawValue = c;
            data.Type = EShYAlgorithm.DataType.Parentesi;
            data.Value = false;
            return data;
        }

        private IData createData(char c, int value)
        {
            var data = new Data();
            data.Precedence = value;
            data.RawValue = c;
            data.Type = EShYAlgorithm.DataType.Data;
            data.Value = (c == 'f' || c == 'F') ? false : true;
            return data;
        }

        private IData createOperator(char c, int value)
        {
            var data = new Data();
            data.Precedence = value;
            data.RawValue = c;
            data.Type = EShYAlgorithm.DataType.Operator;
            data.Value = false;
            return data;
        }
    }
}
