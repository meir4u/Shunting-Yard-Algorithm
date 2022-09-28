using ShuntingYardAlgorithm.Parser.Rule.Token.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Rule.Token.Base
{
    abstract class BaseTokenRule : ITokenRule
    {
        public abstract ITokenRuleResult Execute(string rawData);
        protected abstract IEnumerable<string> getTypeList();
    }
}
