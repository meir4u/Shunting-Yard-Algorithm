using NUnit.Framework;
using ShuntingYardAlgorithm.Config;
using ShuntingYardAlgorithm.Enum;
using ShuntingYardAlgorithm.Factory.Token;
using ShuntingYardAlgorithm.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShantingYardTest
{
    class ParentasiTokenFactoryTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void OpenRawValueTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create('(');
            Assert.AreEqual(token.RawValue, '(');
        }

        [Test]
        public void CloseRawValueTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create(')');
            Assert.AreEqual(token.RawValue, ')');
        }

        [Test]
        public void OpenCorectTokenCreatedTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create('(');
            bool isParentesiToken = token is ParentesiToken;
            Assert.IsTrue(isParentesiToken);
        }

        [Test]
        public void CloseCorectTokenCreatedTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create(')');
            bool isParentesiToken = token is ParentesiToken;
            Assert.IsTrue(isParentesiToken);
        }

        [Test]
        public void OpenParentesiStateTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create('(');
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Type, EParentesi.ParentesiState.Open);
        }

        [Test]
        public void CloseParentesiStateTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create(')');
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Type, EParentesi.ParentesiState.Close);
        }

        [Test]
        public void OpenParentesiPresedenseTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create(')');
            var parentesiToken = token as ParentesiToken;

            Assert.AreEqual(parentesiToken.Precedence, ParentasiTokenConfig.GetPrecedence(EParentesi.ParentesiState.Open));
        }

        [Test]
        public void CloseParentesiPresedenseTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create(')');
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Precedence, ParentasiTokenConfig.GetPrecedence(EParentesi.ParentesiState.Close));
        }

        [Test]
        public void OpenCloseParentesiPresedenseSameTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var openToken = parentasiTokenFactory.Create('(');
            var closeToken = parentasiTokenFactory.Create(')');

            Assert.AreEqual((openToken as ParentesiToken).Precedence, (closeToken as ParentesiToken).Precedence);
        }

        [Test]
        public void OpenParentesiPresedenseZeroTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create('(');

            Assert.AreEqual(0, (token as ParentesiToken).Precedence);
        }

        [Test]
        public void CloseParentesiPresedenseZeroTest()
        {
            var parentasiTokenFactory = new ParentasiTokenFactory();
            var token = parentasiTokenFactory.Create(')');

            Assert.AreEqual(0, (token as ParentesiToken).Precedence);
        }
    }
}
