using ShuntingYardAlgorithm.Parser.Rule.Token;
using ShuntingYardAlgorithm.Parser.Rule.Token.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Parser.Mapper
{
    static class TokenRuleResultMapper
    {
        public static ITokenRuleResult BooleanToken(string rawToken, string rawData)
        {
            ITokenRuleResult result = baseToken(rawToken, rawData);

            result.Type = Base.Enum.EData.Type.Boolean;
            return result;
        }

        public static ITokenRuleResult ParentasiToken(string rawToken, string rawData)
        {
            ITokenRuleResult result = baseToken(rawToken, rawData);

            result.Type = Base.Enum.EData.Type.Parentasi;
            return result;
        }

        public static ITokenRuleResult OperatorToken(string rawToken, string rawData)
        {
            ITokenRuleResult result = baseToken(rawToken, rawData);

            result.Type = Base.Enum.EData.Type.Operator;
            return result;
        }

        private static ITokenRuleResult baseToken(string rawToken, string rawData)
        {
            ITokenRuleResult result = new TokenRuleResult()
            {
                RawTokenStringLength = rawToken.Length,
                RestData = rawData.Substring(rawToken.Length),
                TokenRaw = rawToken
            };
            return result;
        }
    }
}
