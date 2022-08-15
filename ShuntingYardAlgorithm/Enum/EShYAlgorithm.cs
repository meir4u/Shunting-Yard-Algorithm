﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Enum
{
    public class EShYAlgorithm
    {
        public enum OperatorType
        {
            Or = 1,
            And = 2
        }

        public enum ParentesiType
        {
            Open = 0,
            Close
        }

        public enum BooleanType
        {
            Positive,
            Negative
        }
    }
}
