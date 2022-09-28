using ShuntingYardAlgorithm.Parser.Rule.Token.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Rule.Token.Base
{
    internal interface ITokenRule
    {
        ITokenRuleResult Execute(string rawData);
    }
}
