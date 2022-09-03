using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Postfix
{
    internal class OperatorPostfixProcessHandler : PostfixProcessHandler
    {
        internal override void HandleReqeust(IToken token, Queue<IToken> postfix, Stack<IToken> operatorToken)
        {
            if (token is IOperatorToken)
            {
                while (operatorToken.Count > 0 && !(operatorToken.Peek() is IParentesiToken) && (operatorToken.Peek() as IOperatorToken).Precedence > (token as IOperatorToken).Precedence)
                {
                    postfix.Enqueue(operatorToken.Pop());
                }
                operatorToken.Push(token);
            }
            else
            {
                this.nextHandle(token, postfix, operatorToken);
            }
        }
    }
}
