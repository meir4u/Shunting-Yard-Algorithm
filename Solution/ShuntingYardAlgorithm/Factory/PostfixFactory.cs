using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Exceptions.Postfix;
using ShuntingYardAlgorithm.Factory.Handler.Postfix;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Factory
{
    internal class PostfixFactory
    {
        private readonly Stack<IToken> operatorToken = new Stack<IToken>();
        private Queue<IToken> postfix = new Queue<IToken>();
        private readonly PostfixProcessHandler postfixProcessHandler;

        internal PostfixFactory()
        {
            postfixProcessHandler = getHandler();
        }

        public Queue<IToken> Create(Queue<IToken> infix)
        {
            var result = createPostFix(infix);
            resetPostfix();
            return result;
        }

        private void resetPostfix()
        {
            postfix = new Queue<IToken>();
            if (operatorToken.Count > 0) operatorToken.Clear();
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

            if(postfix.Count == 0)
            {
                throw new PostfixEmptyException();
            }

            return postfix;
        }

        private void processToken(IToken token)
        {
            postfixProcessHandler.HandleReqeust(token, postfix, operatorToken);
        }

        private PostfixProcessHandler getHandler()
        {
            try
            {
                PostfixProcessHandler h1 = new BooleanPostfixProcessHandler();
                PostfixProcessHandler h2 = new OperatorPostfixProcessHandler();
                PostfixProcessHandler h3 = new ParentesiPostfixProcessHandler();

                h1.SetSuccessor(h2);
                h2.SetSuccessor(h3);
                return h1;
            }
            catch(Exception ex)
            {
                throw new PostfixProcessHandlerException(ex.Message, ex);
            }
        }
    }
}
