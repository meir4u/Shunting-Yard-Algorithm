using ShuntingYardAlgorithm.Base.Token;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Exceptions.Postfix;
using ShuntingYardAlgorithm.Factory.Handler.Calculator;
using ShuntingYardAlgorithm.Parser.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class CalculatorFactory
    {
        private readonly TokenAbstractFactory tokenAbstractFactory = new TokenAbstractFactory();
        private readonly CalculatorHandler calculatorHandler;
        internal CalculatorFactory()
        {
            calculatorHandler = getCalculatorHandler();
        }

        private CalculatorHandler getCalculatorHandler()
        {
            CalculatorHandler andCalculatorHandler = new AndCalculatorHandler();
            CalculatorHandler orCalculatorHandler = new OrCalculatorHandler();
            orCalculatorHandler.SetSuccessor(andCalculatorHandler);

            return orCalculatorHandler;
        }

        public object Calculate(Queue<IToken> postfix)
        {
            if(postfix == null) throw new PostfixNullException();
            if(postfix.Count == 0) throw new PostfixEmptyException();

            object result = calculate(postfix);

            return result;
        }

        private object calculate(Queue<IToken> postfix)
        {
            Stack<IToken> resultStack = new Stack<IToken>();
            while (postfix.Count > 0)
            {
                pushBooleanTokens(postfix, resultStack);

                while (postfix.Count > 0 && postfix.Peek() is IOperatorToken)
                {
                    calculatorHandler.HandleReqeust(postfix, resultStack);
                }
            }
            return (resultStack.Peek() as BooleanToken).Value;
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
