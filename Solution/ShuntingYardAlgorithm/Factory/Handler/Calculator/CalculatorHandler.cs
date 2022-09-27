using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Exceptions.Calculate;
using ShuntingYardAlgorithm.Exceptions.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Calculator
{
    internal abstract class CalculatorHandler
    {
        protected CalculatorHandler successor = null;
        protected TokenAbstractFactory tokenAbstractFactory = new TokenAbstractFactory();

        internal void SetSuccessor(CalculatorHandler successor)
        {
            this.successor = successor;
        }

        internal abstract void HandleReqeust(Queue<IToken> postfix, Stack<IToken> resultQueue);
        protected abstract void pushToResultStack(object result, Stack<IToken> resultQueue);

        protected void nextHandle(Queue<IToken> postfix, Stack<IToken> resultQueue)
        {
            if (successor != null)
            {
                successor.HandleReqeust(postfix, resultQueue);
            }
            else
            {
                throw new OperatorTypeNotSupportedException($"operator: {(postfix.Peek() as IOperatorToken).Type}");
            }
        }

        protected bool isValidStack(Stack<IToken> resultStack, int minTokenInStack)
        {
            if (resultStack.Count >= minTokenInStack)
            {
                return true;
            }
            else
            {
                throw new CalculateException($"Must Have {2}");
            }
        }
    }
}
