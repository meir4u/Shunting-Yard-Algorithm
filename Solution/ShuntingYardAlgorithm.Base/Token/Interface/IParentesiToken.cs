using ShuntingYardAlgorithm.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Token.Interface
{
    public interface IParentesiToken : IToken
    {
        EParentesi.ParentesiState Type { get; set; }
        int Precedence { get; set; }
    }
}
