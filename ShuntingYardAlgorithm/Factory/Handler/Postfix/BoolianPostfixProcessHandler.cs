using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Postfix
{
    internal class BoolianPostfixProcessHandler : PostfixProcessHandler
    {
        internal override void HandleReqeust(IToken token, Queue<IToken> postfix, Stack<IToken> operatorToken)
        {
            if (token is IBoolianToken)
            {
                postfix.Enqueue(token);
            }
            else
            {
                this.nextHandle(token, postfix, operatorToken);
            }
        }
    }
}
