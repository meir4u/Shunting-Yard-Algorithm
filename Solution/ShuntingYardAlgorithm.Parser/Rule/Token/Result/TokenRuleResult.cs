using ShuntingYardAlgorithm.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Rule.Token.Result
{
    class TokenRuleResult : ITokenRuleResult
    {
        public string RestData { get; set; }
        public string TokenRaw { get; set; }
        public int RawTokenStringLength { get; set; }
        public EData.Type Type { get; set; }
    }
}
