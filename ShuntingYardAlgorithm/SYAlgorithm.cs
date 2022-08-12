using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class SYAlgorithm
    {
        private static Lazy<SYAlgorithm> lazy = new Lazy<SYAlgorithm>(()=>new SYAlgorithm(), true);
        private string rawData { get; set; }
        private Stack<IData> operators = new Stack<IData>();
        private Queue<IData> infix = new Queue<IData>();
        private Queue<IData> postfix = new Queue<IData>();

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

        private Queue<IData> createInfix()
        {
            int length = rawData.Length;
            List<string> qdata = new List<string>();

            for (int i = 0; i < length; i++)
            {
                IData data = TokenFactory.Current.Create(rawData[i]);
                infix.Enqueue(data);
            }

            return infix;
        }

        private void createPostFix()
        {
            while(infix.Count> 0)
            {
                IData token = infix.Dequeue();

                processToken(token);
            }

            while (operators.Count > 0)
            {
                postfix.Enqueue(operators.Pop());
            }
        }
        
        private bool calCulate()
        {
            Queue<IData> resultQueue = new Queue<IData>();
            while(postfix.Count > 0)
            {
                while(postfix.Count > 0 && postfix.Peek() is IBoolianData)
                {
                    resultQueue.Enqueue(postfix.Dequeue());
                }

                while (postfix.Count > 0 && postfix.Peek() is IOperatorData)
                {
                    if(resultQueue.Count >= 2)
                    {
                        bool right = (resultQueue.Dequeue() as IBoolianData).Value;
                        bool left = (resultQueue.Dequeue() as IBoolianData).Value;
                        EShYAlgorithm.OperatorType Operator = (postfix.Dequeue() as IOperatorData).Type;
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
            return (resultQueue.Peek() as BoolianData).Value;
        }

        private void processToken(IData token)
        {
            switch (token.RawValue)
            {
                case '&':
                case '|':
                    while(operators.Count > 0 && !(operators.Peek() is IParentesiData) && (operators.Peek() as IOperatorData).Precedence >= (token as IOperatorData).Precedence)
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
