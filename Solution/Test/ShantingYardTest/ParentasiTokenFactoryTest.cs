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
    class ParentasiTokenFactoryTest
    {
        ParentasiTokenFactory parentasiTokenFactory = new ParentasiTokenFactory();
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void OpenRawValueTest()
        {
            var token = parentasiTokenFactory.Create('(');
            Assert.AreEqual(token.RawValue, '(');
        }

        [Test]
        public void CloseRawValueTest()
        {
            var token = parentasiTokenFactory.Create(')');
            Assert.AreEqual(token.RawValue, ')');
        }

        [Test]
        public void OpenCorectTokenCreatedTest()
        {
            var token = parentasiTokenFactory.Create('(');
            bool isParentesiToken = token is ParentesiToken;
            Assert.IsTrue(isParentesiToken);
        }

        [Test]
        public void CloseCorectTokenCreatedTest()
        {
            var token = parentasiTokenFactory.Create(')');
            bool isParentesiToken = token is ParentesiToken;
            Assert.IsTrue(isParentesiToken);
        }

        [Test]
        public void OpenParentesiStateTest()
        {
            var token = parentasiTokenFactory.Create('(');
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Type, EParentesi.ParentesiState.Open);
        }

        [Test]
        public void CloseParentesiStateTest()
        {
            var token = parentasiTokenFactory.Create(')');
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Type, EParentesi.ParentesiState.Close);
        }

        [Test]
        public void OpenParentesiPresedenseTest()
        {
            var token = parentasiTokenFactory.Create(')');
            var parentesiToken = token as ParentesiToken;

            Assert.AreEqual(parentesiToken.Precedence, ParentasiTokenConfig.GetPrecedence(EParentesi.ParentesiState.Open));
        }

        [Test]
        public void CloseParentesiPresedenseTest()
        {
            var token = parentasiTokenFactory.Create(')');
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Precedence, ParentasiTokenConfig.GetPrecedence(EParentesi.ParentesiState.Close));
        }

        [Test]
        public void OpenCloseParentesiPresedenseSameTest()
        {
            var openToken = parentasiTokenFactory.Create('(');
            var closeToken = parentasiTokenFactory.Create(')');

            Assert.AreEqual((openToken as ParentesiToken).Precedence, (closeToken as ParentesiToken).Precedence);
        }

        [Test]
        public void OpenParentesiPresedenseZeroTest()
        {
            var token = parentasiTokenFactory.Create('(');

            Assert.AreEqual(0, (token as ParentesiToken).Precedence);
        }

        [Test]
        public void CloseParentesiPresedenseZeroTest()
        {
            var token = parentasiTokenFactory.Create(')');

            Assert.AreEqual(0, (token as ParentesiToken).Precedence);
        }
    }
}
