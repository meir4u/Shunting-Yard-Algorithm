using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory.Handler.Postfix;
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
            var handler = getHandler();

            handler.HandleReqeust(token, postfix, operatorToken);
        }

        private PostfixProcessHandler getHandler()
        {
            PostfixProcessHandler h1 = new BooleanPostfixProcessHandler();
            PostfixProcessHandler h2 = new OperatorPostfixProcessHandler();
            PostfixProcessHandler h3 = new ParentesiPostfixProcessHandler();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            return h1;
        }
    }
}
