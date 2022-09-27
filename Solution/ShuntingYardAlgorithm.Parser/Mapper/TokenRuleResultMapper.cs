using ShuntingYardAlgorithm.Parser.Rule.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Mapper
{
    static class TokenRuleResultMapper
    {
        public static ITokenRuleResult BooleanToken(string rawToken, string rawData)
        {
            ITokenRuleResult result = new TokenRuleResult()
            {
                RawTokenStringLength = rawToken.Length,
                RestData = rawData.Substring(rawToken.Length),
                TokenRaw = rawToken,
                Type = Base.Enum.EData.Type.Boolean
            };
            return result;
        }
    }
}
