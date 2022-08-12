using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class SYAlgorithm
    {
        private static Lazy<SYAlgorithm> lazy = new Lazy<SYAlgorithm>(()=>new SYAlgorithm(), true);
        private string rawData { get; set; }
        private Stack<IToken> operators = new Stack<IToken>();
        private Queue<IToken> infix = new Queue<IToken>();
        private Queue<IToken> postfix = new Queue<IToken>();

        private SYAlgorithm()
        {

        }

        public static bool CalCulate(string rawData)
        {
            bool result = lazy.Value.getResult(rawData);
            return result;
        }

        private bool getResult(string rawData)
        {
            this.rawData = rawData;
            infix = createInfix();
            createPostFix();
            bool calc = calCulate();
            return calc;
            //return infix;
        }

        private Queue<IToken> createInfix()
        {
            int length = rawData.Length;
            List<string> qdata = new List<string>();

            for (int i = 0; i < length; i++)
            {
                IToken data = TokenFactory.Current.Create(rawData[i]);
                infix.Enqueue(data);
            }

            return infix;
        }

        private void createPostFix()
        {
            while(infix.Count> 0)
            {
                IToken token = infix.Dequeue();

                processToken(token);
            }

            while (operators.Count > 0)
            {
                postfix.Enqueue(operators.Pop());
            }
        }
        
        private bool calCulate()
        {
            Queue<IToken> resultQueue = new Queue<IToken>();
            while(postfix.Count > 0)
            {
                while(postfix.Count > 0 && postfix.Peek() is IBoolianToken)
                {
                    resultQueue.Enqueue(postfix.Dequeue());
                }

                while (postfix.Count > 0 && postfix.Peek() is IOperatorToken)
                {
                    if(resultQueue.Count >= 2)
                    {
                        bool right = (resultQueue.Dequeue() as IBoolianToken).Value;
                        bool left = (resultQueue.Dequeue() as IBoolianToken).Value;
                        EShYAlgorithm.OperatorType Operator = (postfix.Dequeue() as IOperatorToken).Type;
                        bool result;
                        if(Operator == EShYAlgorithm.OperatorType.And)
                        {
                            result = left && right;
                        }
                        else
                        {
                            result = left || right;
                        }
                        char tmpChar = result ? 't' : 'f';
                        resultQueue.Enqueue(TokenFactory.Current.Create(tmpChar));
                    }
                    else
                    {
                        throw new Exception("error!");
                    }
                }
            }
            return (resultQueue.Peek() as BoolianToken).Value;
        }

        private void processToken(IToken token)
        {
            switch (token.RawValue)
            {
                case '&':
                case '|':
                    while(operators.Count > 0 && !(operators.Peek() is IParentesiToken) && (operators.Peek() as IOperatorToken).Precedence >= (token as IOperatorToken).Precedence)
                    {
                        postfix.Enqueue(operators.Pop());
                    }
                    operators.Push(token);
                    break;
                case '(':
                    operators.Push(token);
                    break;
                case ')':
                    while(operators.Count > 0 && operators.Peek().RawValue != '(')
                    {
                        postfix.Enqueue(operators.Pop());
                    }
                    operators.Pop();
                    break;
                default:
                    postfix.Enqueue(token);
                    break;
            }
        }
    }
}
