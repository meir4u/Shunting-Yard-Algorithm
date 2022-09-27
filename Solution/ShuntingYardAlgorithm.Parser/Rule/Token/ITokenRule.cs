using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Rule.Token
{
    internal interface ITokenRule
    {
        ITokenRuleResult Execute(string rawData);
    }
}
