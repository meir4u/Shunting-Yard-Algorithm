using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class SYAlgorithm
    {
        private string rawData { get; set; }
        private Stack<IData> operators = new Stack<IData>();
        private Queue<IData> infix = new Queue<IData>();
        private Queue<IData> postfix = new Queue<IData>();

        public SYAlgorithm(string rawData)
        {
            this.rawData = rawData;
        }

        public bool create()
        {
            infix = createInfix();
            createPostFix();
            bool calc = CalCulate();
            return calc;
            //return infix;
        }

        private Queue<IData> createInfix()
        {
            int length = rawData.Length;
            List<string> qdata = new List<string>();

            for (int i = 0; i < length; i++)
            {
                IData data = DataFactory.Current.Create(rawData[i]);
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

        private bool CalCulate()
        {
            Queue<IData> resultQueue = new Queue<IData>();
            while(postfix.Count > 1)
            {
                while(postfix.Count > 0 && postfix.Peek().Type == EShYAlgorithm.DataType.Data)
                {
                    resultQueue.Enqueue(postfix.Dequeue());
                }

                while (postfix.Count > 0 && postfix.Peek().Type == EShYAlgorithm.DataType.Operator)
                {
                    if(resultQueue.Count >= 2)
                    {
                        bool right = resultQueue.Dequeue().Value;
                        bool left = resultQueue.Dequeue().Value;
                        char Operator = postfix.Dequeue().RawValue;
                        bool result;
                        if(Operator == '&')
                        {
                            result = left && right;
                        }
                        else
                        {
                            result = left || right;
                        }
                        char tmpChar = result ? 't' : 'f';
                        resultQueue.Enqueue(DataFactory.Current.Create(tmpChar));
                    }
                    else
                    {
                        throw new Exception("error!");
                    }
                }
            }
            return resultQueue.Peek().Value;
        }

        private void processToken(IData token)
        {
            switch (token.RawValue)
            {
                case '&':
                case '|':
                    while(operators.Count > 0 && operators.Peek().Type != EShYAlgorithm.DataType.Parentesi && operators.Peek().Precedence >= token.Precedence)
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
