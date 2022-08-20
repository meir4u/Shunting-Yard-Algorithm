﻿using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Exceptions;
using ShuntingYardAlgorithm.Factory.Handler.Calculator;
using ShuntingYardAlgorithm.Token;
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

        public bool Calculate(Queue<IToken> postfix)
        {
            if(postfix == null) throw new PostfixNullException();
            if(postfix.Count == 0) throw new PostfixEmptyException();

            bool result = calculate(postfix);

            return result;
        }

        private bool calculate(Queue<IToken> postfix)
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
