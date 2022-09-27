using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Rule.Token
{
    abstract class BaseTokenRule : ITokenRule
    {
        public abstract ITokenRuleResult Execute(string rawData);
        protected abstract IEnumerable<string> getTypeList();
    }
}
