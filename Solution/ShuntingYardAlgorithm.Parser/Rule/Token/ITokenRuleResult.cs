using ShuntingYardAlgorithm.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Rule.Token
{
    interface ITokenRuleResult
    {
        string RestData { get; set; }
        string TokenRaw { get; set; }
        int RawTokenStringLength { get; set; }
        EData.Type Type { get; set; }
    }
}
