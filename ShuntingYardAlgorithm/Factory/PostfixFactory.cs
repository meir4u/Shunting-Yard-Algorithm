using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class PostfixFactory
    {
        private static Lazy<PostfixFactory> lazy = new Lazy<PostfixFactory>(()=>new PostfixFactory(), true);
        private static PostfixFactory instance { get => lazy.Value; }

        private Stack<IToken> operatorToken = new Stack<IToken>();
        private Queue<IToken> postfix = new Queue<IToken>();

        private PostfixFactory()
        {

        }

        public static Queue<IToken> Create(Queue<IToken> infix)
        {
            lock (instance)
            {
                var result = instance.createPostFix(infix);
                lazy.Value.resetPostfix();
                return result;
            }
        }

        private void resetPostfix()
        {
            postfix = new Queue<IToken>();
        }

        private Queue<IToken> createPostFix(Queue<IToken> infix)
        {
            while (infix.Count > 0)
            {
                IToken token = infix.Dequeue();

                processToken(token);
            }

            while (operatorToken.Count > 0)
            {
                postfix.Enqueue(operatorToken.Pop());
            }
            return postfix;
        }

        private void processToken(IToken token)
        {
            if (token is IOperatorToken)
            {
                while (operatorToken.Count > 0 && !(operatorToken.Peek() is IParentesiToken) && (operatorToken.Peek() as IOperatorToken).Precedence >= (token as IOperatorToken).Precedence)
                {
                    postfix.Enqueue(operatorToken.Pop());
                }
                operatorToken.Push(token);
            }
            else if (token is IParentesiToken)
            {
                var tmp = token as IParentesiToken;
                if (tmp.Type == EShYAlgorithm.ParentesiType.Open)
                {
                    operatorToken.Push(token);
                }
                else
                {
                    while (operatorToken.Count > 0 && operatorToken.Peek() is IParentesiToken && (operatorToken.Peek() as IParentesiToken).Type != EShYAlgorithm.ParentesiType.Open)
                    {
                        postfix.Enqueue(operatorToken.Pop());
                    }
                    operatorToken.Pop();
                }
            }
            else
            {
                postfix.Enqueue(token);
            }
        }
    }
}
