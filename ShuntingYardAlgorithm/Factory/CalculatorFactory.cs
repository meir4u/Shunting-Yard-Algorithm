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
            Stack<IToken> resultQueue = new Stack<IToken>();
            while (postfix.Count > 0)
            {
                enqueueBoolianTokens(postfix, resultQueue);

                while (postfix.Count > 0 && postfix.Peek() is IOperatorToken)
                {
                    if (resultQueue.Count >= 2)
                    {
                        bool result = getResult(postfix, resultQueue);
                        resultToResultQueue(result, resultQueue);
                    }
                    else
                    {
                        throw new Exception("error!");
                    }
                }
            }
            return (resultQueue.Peek() as BoolianToken).Value;
        }

        private void resultToResultQueue(bool result, Stack<IToken> resultQueue)
        {
            char tmpChar = result ? 't' : 'f';
            resultQueue.Push(TokenAbstractFactory.Create(tmpChar));
        }

        private bool getResult(Queue<IToken> postfix, Stack<IToken> resultQueue)
        {
            bool result;
            bool right = (resultQueue.Pop() as IBoolianToken).Value;
            bool left = (resultQueue.Pop() as IBoolianToken).Value;
            EShYAlgorithm.OperatorType Operator = (postfix.Dequeue() as IOperatorToken).Type;
            if (Operator == EShYAlgorithm.OperatorType.And)
            {
                result = left && right;
            }
            else
            {
                result = left || right;
            }
            return result;
        }

        private void enqueueBoolianTokens(Queue<IToken> postfix, Stack<IToken> resultQueue)
        {
            while (postfix.Count > 0 && postfix.Peek() is IBoolianToken)
            {
                resultQueue.Push(postfix.Dequeue());
            }
        }
    }
}
