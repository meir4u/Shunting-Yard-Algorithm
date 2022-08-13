using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Postfix
{
    internal class ParentesiPostfixProcessHandler : PostfixProcessHandler
    {
        internal override void HandleReqeust(IToken token, Queue<IToken> postfix, Stack<IToken> operatorToken)
        {
            if (token is IParentesiToken)
            {
                var tmp = token as IParentesiToken;
                if (tmp.Type == EShYAlgorithm.ParentesiType.Open)
                {
                    operatorToken.Push(token);
                }
                else
                {
                    while (operatorToken.Count > 0 && (operatorToken.Peek() is IParentesiToken) == false)
                    {
                        postfix.Enqueue(operatorToken.Pop());
                    }
                    operatorToken.Pop();
                }
            }
            else
            {
                this.nextHandle(token, postfix, operatorToken);
            }
        }
    }
}
