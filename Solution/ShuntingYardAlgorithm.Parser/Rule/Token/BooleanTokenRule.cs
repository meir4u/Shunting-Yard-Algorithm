using ShuntingYardAlgorithm.Parser.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Rule.Token
{
    internal class BooleanTokenRule : BaseTokenRule
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
            if (string.IsNullOrEmpty(v) == false || Char.IsLetterOrDigit(v[0])) return false;
            return true;
        }

        protected override IEnumerable<string> getTypeList()
        {
            List<string> data = new List<string>();
            data.Add("t");
            data.Add("True");
            data.Add("f");
            data.Add("False");
            return data;
        }



    }
}
