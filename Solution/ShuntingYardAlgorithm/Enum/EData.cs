using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Enum
{
    public class EData
    {
        public enum Type
        {
            None = 0,
            Number,
            String,
            Boolean,
            InnumerableNumber,
            InnumerableString,
            InnumerableBoolean
        }
    }
}
