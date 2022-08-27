using NUnit.Framework;
using ShuntingYardAlgorithm;
using ShuntingYardAlgorithm.Factory;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShantingYardTest
{
    class InfixFactoryTest
    {
        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        public void QueueTokenTypesTest()
        {
            string rawData = "t&t";
            Queue<IToken> expected = new Queue<IToken>(new List<IToken>{
                new BooleanToken(),
                new OperatorToken(),
                new BooleanToken()
            });
            var infixtokens = new InfixFactory().Create(rawData);
            
            while(expected.Count > 0)
            {
                Assert.That(infixtokens.Dequeue().GetType(), Is.EqualTo(expected.Dequeue().GetType()));
            }
        }

        [Test]
        public void QueueTokenLengthTest()
        {
            string rawData = "t&t";
            Queue<IToken> expected = new Queue<IToken>(new List<IToken>{
                new BooleanToken(),
                new OperatorToken(),
                new BooleanToken()
            });

            var infixtokens = new InfixFactory().Create(rawData);

            Assert.That(infixtokens.Count, Is.EqualTo(expected.Count));
        }
    }
}
