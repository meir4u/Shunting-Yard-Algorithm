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
    class ParentasiTokenFactoryTest : Base
    {
        ParentasiTokenFactory parentasiTokenFactory = new ParentasiTokenFactory();
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void OpenRawValueTest()
        {
            var token = parentasiTokenFactory.Create(OPEN_PARENTASI);
            Assert.AreEqual(token.RawValue, OPEN_PARENTASI);
        }

        [Test]
        public void CloseRawValueTest()
        {
            var token = parentasiTokenFactory.Create(CLOSE_PARENTASI);
            Assert.AreEqual(token.RawValue, CLOSE_PARENTASI);
        }

        [Test]
        public void OpenCorectTokenCreatedTest()
        {
            var token = parentasiTokenFactory.Create(OPEN_PARENTASI);
            bool isParentesiToken = token is ParentesiToken;
            Assert.IsTrue(isParentesiToken);
        }

        [Test]
        public void CloseCorectTokenCreatedTest()
        {
            var token = parentasiTokenFactory.Create(CLOSE_PARENTASI);
            bool isParentesiToken = token is ParentesiToken;
            Assert.IsTrue(isParentesiToken);
        }

        [Test]
        public void OpenParentesiStateTest()
        {
            var token = parentasiTokenFactory.Create(OPEN_PARENTASI);
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Type, EParentesi.ParentesiState.Open);
        }

        [Test]
        public void CloseParentesiStateTest()
        {
            var token = parentasiTokenFactory.Create(CLOSE_PARENTASI);
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Type, EParentesi.ParentesiState.Close);
        }

        [Test]
        public void OpenParentesiPresedenseTest()
        {
            var token = parentasiTokenFactory.Create(CLOSE_PARENTASI);
            var parentesiToken = token as ParentesiToken;

            Assert.AreEqual(parentesiToken.Precedence, ParentasiTokenConfig.GetPrecedence(EParentesi.ParentesiState.Open));
        }

        [Test]
        public void CloseParentesiPresedenseTest()
        {
            var token = parentasiTokenFactory.Create(CLOSE_PARENTASI);
            var parentesiToken = token as ParentesiToken;
            Assert.AreEqual(parentesiToken.Precedence, ParentasiTokenConfig.GetPrecedence(EParentesi.ParentesiState.Close));
        }

        [Test]
        public void OpenCloseParentesiPresedenseSameTest()
        {
            var openToken = parentasiTokenFactory.Create(OPEN_PARENTASI);
            var closeToken = parentasiTokenFactory.Create(CLOSE_PARENTASI);

            Assert.AreEqual((openToken as ParentesiToken).Precedence, (closeToken as ParentesiToken).Precedence);
        }

        [Test]
        public void OpenParentesiPresedenseZeroTest()
        {
            var token = parentasiTokenFactory.Create(OPEN_PARENTASI);

            Assert.AreEqual(0, (token as ParentesiToken).Precedence);
        }

        [Test]
        public void CloseParentesiPresedenseZeroTest()
        {
            var token = parentasiTokenFactory.Create(CLOSE_PARENTASI);

            Assert.AreEqual(0, (token as ParentesiToken).Precedence);
        }
    }
}
