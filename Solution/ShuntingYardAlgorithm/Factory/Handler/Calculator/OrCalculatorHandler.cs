using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory.Handler.Calculator
{
    internal class OrCalculatorHandler : CalculatorHandler
    {
        private const int minTokenInStack = 2;

        internal override void HandleReqeust(Queue<IToken> postfix, Stack<IToken> resultStack)
        {
            isValidStack(resultStack, minTokenInStack);

            if ((postfix.Peek() as IOperatorToken).Type == EOperator.OperatorType.Or)
            {
                bool tempResult;
                bool right = (bool)(resultStack.Pop() as IBooleanToken).Value;
                bool left = (bool)(resultStack.Pop() as IBooleanToken).Value;
                EOperator.OperatorType Operator = (postfix.Dequeue() as IOperatorToken).Type;

                tempResult = left || right;
                pushToResultStack(tempResult, resultStack);
            }
            else
            {
                successor.HandleReqeust(postfix, resultStack);
            }
        }

        protected override void pushToResultStack(object result, Stack<IToken> resultQueue)
        {
            char tmpChar = (bool)result ? 't' : 'f';
            resultQueue.Push(tokenAbstractFactory.Create(tmpChar));
        }
    }
}
