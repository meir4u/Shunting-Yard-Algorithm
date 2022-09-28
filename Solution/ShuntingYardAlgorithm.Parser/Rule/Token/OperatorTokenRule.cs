using ShuntingYardAlgorithm.Parser.Mapper;
using ShuntingYardAlgorithm.Parser.Rule.Token.Base;
using ShuntingYardAlgorithm.Parser.Rule.Token.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Rule.Token
{
    internal class OperatorTokenRule : BaseTokenRule
    {
        public override ITokenRuleResult Execute(string rawData)
        {
            var typeList = getTypeList();
            ITokenRuleResult result = null;
            foreach (var item in typeList)
            {
                int index = rawData.IndexOf(item, StringComparison.CurrentCultureIgnoreCase);
                if(index == 0 && isExact(rawData.Substring(item.Length)))
                {
                    result = TokenRuleResultMapper.BooleanToken(item, rawData);
                    break;
                }
            }

            return result;
        }

        private bool isExact(string v)
        {
            if (string.IsNullOrEmpty(v) == false || getTypeList().ToList().Contains(v[0].ToString())) return false;
            return true;
        }

        protected override IEnumerable<string> getTypeList()
        {
            List<string> data = new List<string>();
            data.Add("&");
            data.Add("|");
            return data;
        }



    }
}
