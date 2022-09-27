using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Exceptions;
using ShuntingYardAlgorithm.Exceptions.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Postfix
{
    internal abstract class PostfixProcessHandler
    {
        protected PostfixProcessHandler successor = null;
        internal void SetSuccessor(PostfixProcessHandler handler)
        {
            this.successor = handler;
        }

        internal abstract void HandleReqeust(IToken token, Queue<IToken> postfix, Stack<IToken> operatorToken);

        protected void nextHandle(IToken token, Queue<IToken> postfix, Stack<IToken> operatorToken)
        {
            if (successor != null)
            {
                successor.HandleReqeust(token, postfix, operatorToken);
            }
            else
            {
                throw new ProcessHandlerNotSupportedException($"Not Supported process handler");
            }
        }
    }
}
