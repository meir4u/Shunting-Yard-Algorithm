using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class CalculatorFactory
    {
        private static Lazy<CalculatorFactory> lazy = new Lazy<CalculatorFactory>(()=>new CalculatorFactory(), true);
        private static CalculatorFactory instance { get => lazy.Value; }

        private CalculatorFactory()
        {

        }

        public static bool Calculate(Queue<IToken> postfix)
        {
            lock (instance)
            {
                bool result = instance.calculate(postfix);

                return result;
            }
        }

        private bool calculate(Queue<IToken> postfix)
        {
            Stack<IToken> resultStack = new Stack<IToken>();
            while (postfix.Count > 0)
            {
                pushBooleanTokens(postfix, resultStack);

                while (postfix.Count > 0 && postfix.Peek() is IOperatorToken)
                {
                    if (resultStack.Count >= 2)
                    {
                        bool result = getResult(postfix, resultStack);
                        pushToResultStack(result, resultStack);
                    }
                    else
                    {
                        throw new System.Exception("error!");
                    }
                }
            }
            return (resultStack.Peek() as BooleanToken).Value;
        }

        private void pushToResultStack(bool result, Stack<IToken> resultQueue)
        {
            char tmpChar = result ? 't' : 'f';
            resultQueue.Push(TokenAbstractFactory.Create(tmpChar));
        }

        private bool getResult(Queue<IToken> postfix, Stack<IToken> resultQueue)
        {
            bool result;
            bool right = (resultQueue.Pop() as IBooleanToken).Value;
            bool left = (resultQueue.Pop() as IBooleanToken).Value;
            EOperator.OperatorType Operator = (postfix.Dequeue() as IOperatorToken).Type;
            if (Operator == EOperator.OperatorType.And)
            {
                result = left && right;
            }
            else
            {
                result = left || right;
            }
            return result;
        }

        private void pushBooleanTokens(Queue<IToken> postfix, Stack<IToken> resultQueue)
        {
            while (postfix.Count > 0 && postfix.Peek() is IBooleanToken)
            {
                resultQueue.Push(postfix.Dequeue());
            }
        }
    }
}
