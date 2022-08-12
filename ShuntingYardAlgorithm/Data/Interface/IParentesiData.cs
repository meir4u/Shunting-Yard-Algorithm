using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IParentesiData : IData
    {
        EShYAlgorithm.ParentesiType Type { get; set; }
        int Precedence { get; set; }
    }
}
