using NUnit.Framework;
using ShuntingYardAlgorithm.Base.Enum;
using ShuntingYardAlgorithm.Base.Token;
using ShuntingYardAlgorithm.Base.Config;
using ShuntingYardAlgorithm.Parser.Factory.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShantingYardTest
{
    class AndOperatorTokenFactoryTest : Base
    {
        OperatorTokenFactory operatorTokenFactory = new OperatorTokenFactory();
        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        public void RawValueTest()
        {
            var token = operatorTokenFactory.Create(AND);
            Assert.AreEqual(token.RawValue, AND);
        }

        [Test]
        public void CorectTokenCreatedTest()
        {
            var token = operatorTokenFactory.Create(AND);
            bool isOperatorToken = token is OperatorToken;
            Assert.IsTrue(isOperatorToken);
        }

        [Test]
        public void OperatorTypeTest()
        {
            var token = operatorTokenFactory.Create(AND);
            var operatorToken = (token as OperatorToken);
            Assert.AreEqual(operatorToken.Type, EOperator.OperatorType.And);
        }

        [Test]
        public void OperatorAssociativeTest()
        {
            var token = operatorTokenFactory.Create(AND);
            var operatorToken = (token as OperatorToken);
            Assert.AreEqual(operatorToken.Associative, OperatorTokenConfig.GetAssociative(EOperator.OperatorType.And));
        }

        [Test]
        public void OperatorPresedenseTest()
        {
            var token = operatorTokenFactory.Create(AND);
            var operatorToken = (token as OperatorToken);
            Assert.AreEqual(operatorToken.Precedence, OperatorTokenConfig.GetPrecedence(EOperator.OperatorType.And));
        }
    }
}
