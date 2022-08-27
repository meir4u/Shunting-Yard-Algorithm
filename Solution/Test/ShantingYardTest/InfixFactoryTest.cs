using NUnit.Framework;
using ShuntingYardAlgorithm;
using ShuntingYardAlgorithm.Factory;
using ShuntingYardAlgorithm.Factory.Token;
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
        [TestCaseSource("QueueSimpleTokenData")]
        [TestCaseSource("QueueSimpleTokenDataWithParentasi")]
        [TestCaseSource("QueueMiddleTokenDataWithParentasi")]
        [TestCaseSource("QueueMixedTokenDataWithParentasi")]
        public void QueueTokenTypesTest(string rawData, Queue<IToken> expected)
        {
            var infixtokens = new InfixFactory().Create(rawData);

            Assert.That(expected.Count, Is.Not.EqualTo(0), "Expected Test case wrong!");

            while(expected.Count > 0)
            {
                Assert.That(infixtokens.Dequeue().GetType(), Is.EqualTo(expected.Dequeue().GetType()));
            }
        }

        [Test]
        [TestCaseSource("QueueSimpleTokenData")]
        [TestCaseSource("QueueSimpleTokenDataWithParentasi")]
        [TestCaseSource("QueueMiddleTokenDataWithParentasi")]
        [TestCaseSource("QueueMixedTokenDataWithParentasi")]
        public void QueueTokenLengthTest(string rawData, Queue<IToken> expected)
        {
            var infixtokens = new InfixFactory().Create(rawData);
            Assert.That(expected.Count, Is.Not.EqualTo(0), "Expected Test case wrong!");

            Assert.That(infixtokens.Count, Is.EqualTo(expected.Count));
        }

        private static IEnumerable<TestCaseData> QueueSimpleTokenData()
        {
            Queue<IToken> expectedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t')
            });

            Queue<IToken> expectedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f')
            });

            Queue<IToken> expectedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t')
            });

            Queue<IToken> expectedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f')
            });


            yield return new TestCaseData("t&t", new Queue<IToken>(expectedTandT)).SetName("Simple - 2 Same Boolean(t) with &");
            yield return new TestCaseData("T&T", new Queue<IToken>(expectedTandT)).SetName("Simple - 2 Same Boolean(t) with &");
            yield return new TestCaseData("T&t", new Queue<IToken>(expectedTandT)).SetName("Simple - 2 Same Boolean(t) with &");
            yield return new TestCaseData("t&T", new Queue<IToken>(expectedTandT)).SetName("Simple - 2 Same Boolean(t) with &");

            yield return new TestCaseData("f&f", new Queue<IToken>(expectedFandF)).SetName("Simple - 2 Same Boolean(f) with &");
            yield return new TestCaseData("F&F", new Queue<IToken>(expectedFandF)).SetName("Simple - 2 Same Boolean(f) with &");
            yield return new TestCaseData("F&f", new Queue<IToken>(expectedFandF)).SetName("Simple - 2 Same Boolean(f) with &");
            yield return new TestCaseData("f&F", new Queue<IToken>(expectedFandF)).SetName("Simple - 2 Same Boolean(f) with &");

            yield return new TestCaseData("t|t", new Queue<IToken>(expectedTorT)).SetName("Simple - 2 Same Boolean(t) with |");
            yield return new TestCaseData("T|T", new Queue<IToken>(expectedTorT)).SetName("Simple - 2 Same Boolean(t) with |");
            yield return new TestCaseData("T|t", new Queue<IToken>(expectedTorT)).SetName("Simple - 2 Same Boolean(t) with |");
            yield return new TestCaseData("t|T", new Queue<IToken>(expectedTorT)).SetName("Simple - 2 Same Boolean(t) with |");

            yield return new TestCaseData("f|f", new Queue<IToken>(expectedForF)).SetName("Simple - 2 Same Boolean(f) with |");
            yield return new TestCaseData("F|F", new Queue<IToken>(expectedForF)).SetName("Simple - 2 Same Boolean(f) with |");
            yield return new TestCaseData("F|f", new Queue<IToken>(expectedForF)).SetName("Simple - 2 Same Boolean(f) with |");
            yield return new TestCaseData("f|F", new Queue<IToken>(expectedForF)).SetName("Simple - 2 Same Boolean(f) with |");
        }
        
        private static IEnumerable<TestCaseData> QueueSimpleTokenDataWithParentasi()
        {
            Queue<IToken> expectedTandT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
            });

            Queue<IToken> expectedFandF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
            });

            Queue<IToken> expectedTorT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
            });

            Queue<IToken> expectedForF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
            });


            yield return new TestCaseData("(t&t)", new Queue<IToken>(expectedTandT)).SetName("Simple - 2 Same Boolean(t) with &  and WithParentasi");
            yield return new TestCaseData("(T&T)", new Queue<IToken>(expectedTandT)).SetName("Simple - 2 Same Boolean(t) with & and WithParentasi");
            yield return new TestCaseData("(T&t)", new Queue<IToken>(expectedTandT)).SetName("Simple - 2 Same Boolean(t) with & and WithParentasi");
            yield return new TestCaseData("(t&T)", new Queue<IToken>(expectedTandT)).SetName("Simple - 2 Same Boolean(t) with & and WithParentasi");

            yield return new TestCaseData("(f&f)", new Queue<IToken>(expectedFandF)).SetName("Simple - 2 Same Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("(F&F)", new Queue<IToken>(expectedFandF)).SetName("Simple - 2 Same Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("(F&f)", new Queue<IToken>(expectedFandF)).SetName("Simple - 2 Same Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("(f&F)", new Queue<IToken>(expectedFandF)).SetName("Simple - 2 Same Boolean(f) with & and WithParentasi");

            yield return new TestCaseData("(t|t)", new Queue<IToken>(expectedTorT)).SetName("Simple - 2 Same Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("(T|T)", new Queue<IToken>(expectedTorT)).SetName("Simple - 2 Same Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("(T|t)", new Queue<IToken>(expectedTorT)).SetName("Simple - 2 Same Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("(t|T)", new Queue<IToken>(expectedTorT)).SetName("Simple - 2 Same Boolean(t) with | and WithParentasi");

            yield return new TestCaseData("(f|f)", new Queue<IToken>(expectedForF)).SetName("Simple - 2 Same Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("(F|F)", new Queue<IToken>(expectedForF)).SetName("Simple - 2 Same Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("(F|f)", new Queue<IToken>(expectedForF)).SetName("Simple - 2 Same Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("(f|F)", new Queue<IToken>(expectedForF)).SetName("Simple - 2 Same Boolean(f) with | and WithParentasi");
        }

        private static IEnumerable<TestCaseData> QueueMiddleTokenDataWithParentasi()
        {
            Queue<IToken> expectedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
            });

            Queue<IToken> expectedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
            });

            Queue<IToken> expectedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
            });

            Queue<IToken> expectedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
            });


            yield return new TestCaseData("t&(t&t)&t", new Queue<IToken>(expectedTandT)).SetName("Middle - 4 Same Boolean(t) with &  and WithParentasi");
            yield return new TestCaseData("T&(T&T)&T", new Queue<IToken>(expectedTandT)).SetName("Middle - 4 Same Boolean(t) with & and WithParentasi");
            yield return new TestCaseData("T&(T&t)&t", new Queue<IToken>(expectedTandT)).SetName("Middle - 4 Same Boolean(t) with & and WithParentasi");
            yield return new TestCaseData("t&(t&T)&T", new Queue<IToken>(expectedTandT)).SetName("Middle - 4 Same Boolean(t) with & and WithParentasi");

            yield return new TestCaseData("f&(f&f)&f", new Queue<IToken>(expectedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("F&(F&F)&F", new Queue<IToken>(expectedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("F&(F&f)&f", new Queue<IToken>(expectedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("f&(f&F)&F", new Queue<IToken>(expectedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi");

            yield return new TestCaseData("t|(t|t)|t", new Queue<IToken>(expectedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("T|(T|T)|T", new Queue<IToken>(expectedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("T|(T|t)|t", new Queue<IToken>(expectedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("t|(t|T)|T", new Queue<IToken>(expectedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi");

            yield return new TestCaseData("f|(f|f)|f", new Queue<IToken>(expectedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("F|(F|F)|F", new Queue<IToken>(expectedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("F|(F|f)|f", new Queue<IToken>(expectedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("f|(f|F)|F", new Queue<IToken>(expectedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi");

            Queue<IToken> expectedMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
            });

            Queue<IToken> expectedMixedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
            });

            Queue<IToken> expectedMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
            });

            Queue<IToken> expectedMixedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
            });


            yield return new TestCaseData("t&(t&t)|t", new Queue<IToken>(expectedMixedTandT)).SetName("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed");
            yield return new TestCaseData("T&(T&T)|T", new Queue<IToken>(expectedMixedTandT)).SetName("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed");
            yield return new TestCaseData("T&(T&t)|t", new Queue<IToken>(expectedMixedTandT)).SetName("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed");
            yield return new TestCaseData("t&(t&T)|T", new Queue<IToken>(expectedMixedTandT)).SetName("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed");

            yield return new TestCaseData("f&(f|f)&f", new Queue<IToken>(expectedMixedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed");
            yield return new TestCaseData("F&(F|F)&F", new Queue<IToken>(expectedMixedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed");
            yield return new TestCaseData("F&(F|f)&f", new Queue<IToken>(expectedMixedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed");
            yield return new TestCaseData("f&(f|F)&F", new Queue<IToken>(expectedMixedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed");

            yield return new TestCaseData("t&(t|t)|t", new Queue<IToken>(expectedMixedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed");
            yield return new TestCaseData("T&(T|T)|T", new Queue<IToken>(expectedMixedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed");
            yield return new TestCaseData("T&(T|t)|t", new Queue<IToken>(expectedMixedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed");
            yield return new TestCaseData("t&(t|T)|T", new Queue<IToken>(expectedMixedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed");

            yield return new TestCaseData("f|(f&f)|f", new Queue<IToken>(expectedMixedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed");
            yield return new TestCaseData("F|(F&F)|F", new Queue<IToken>(expectedMixedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed");
            yield return new TestCaseData("F|(F&f)|f", new Queue<IToken>(expectedMixedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed");
            yield return new TestCaseData("f|(f&F)|F", new Queue<IToken>(expectedMixedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed");
        }
        
        private static IEnumerable<TestCaseData> QueueMixedTokenDataWithParentasi()
        {
            Queue<IToken> expectedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
            });

            Queue<IToken> expectedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
            });

            Queue<IToken> expectedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
            });

            Queue<IToken> expectedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
            });


            yield return new TestCaseData("t&(t&t)&t|t&(t&t)&f", new Queue<IToken>(expectedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with &  and WithParentasi");
            yield return new TestCaseData("T&(T&T)&T|T&(T&T)&F", new Queue<IToken>(expectedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with & and WithParentasi");
            yield return new TestCaseData("T&(T&t)&t|T&(T&t)&f", new Queue<IToken>(expectedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with & and WithParentasi");
            yield return new TestCaseData("t&(t&T)&T|t&(t&T)&F", new Queue<IToken>(expectedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with & and WithParentasi");

            yield return new TestCaseData("f&(f&f)&f|f&(f&t)&f", new Queue<IToken>(expectedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("F&(F&F)&F|F&(F&T)&F", new Queue<IToken>(expectedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("F&(F&f)&f|F&(F&t)&f", new Queue<IToken>(expectedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi");
            yield return new TestCaseData("f&(f&F)&F|f&(f&T)&F", new Queue<IToken>(expectedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi");

            yield return new TestCaseData("t|(t|f)|t&t|(t|t)|t", new Queue<IToken>(expectedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("T|(T|F)|T&T|(T|T)|T", new Queue<IToken>(expectedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("T|(T|f)|t&T|(T|t)|t", new Queue<IToken>(expectedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi");
            yield return new TestCaseData("t|(t|F)|T&t|(t|T)|T", new Queue<IToken>(expectedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi");

            yield return new TestCaseData("t|(f|f)|f&f|(f|f)|f", new Queue<IToken>(expectedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("T|(F|F)|F&F|(F|F)|F", new Queue<IToken>(expectedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("T|(F|f)|f&F|(F|f)|f", new Queue<IToken>(expectedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi");
            yield return new TestCaseData("t|(f|F)|F&f|(f|F)|F", new Queue<IToken>(expectedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi");

            Queue<IToken> expectedMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
            });

            Queue<IToken> expectedMixedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
            });

            Queue<IToken> expectedMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
            });

            Queue<IToken> expectedMixedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
            });


            yield return new TestCaseData("t&(t&t)|t|t&(t&f)|t", new Queue<IToken>(expectedMixedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed");
            yield return new TestCaseData("T&(T&T)|T|T&(T&F)|T", new Queue<IToken>(expectedMixedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed");
            yield return new TestCaseData("T&(T&t)|t|T&(T&f)|t", new Queue<IToken>(expectedMixedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed");
            yield return new TestCaseData("t&(t&T)|T|t&(t&F)|T", new Queue<IToken>(expectedMixedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed");

            yield return new TestCaseData("f&(f|f)&f&f&(f|f)&t", new Queue<IToken>(expectedMixedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed");
            yield return new TestCaseData("F&(F|F)&F&F&(F|F)&T", new Queue<IToken>(expectedMixedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed");
            yield return new TestCaseData("F&(F|f)&f&F&(F|f)&t", new Queue<IToken>(expectedMixedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed");
            yield return new TestCaseData("f&(f|F)&F&f&(f|F)&T", new Queue<IToken>(expectedMixedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed");

            yield return new TestCaseData("t&(t|t)|f|t&(t|t)|t", new Queue<IToken>(expectedMixedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed");
            yield return new TestCaseData("T&(T|T)|F|T&(T|T)|T", new Queue<IToken>(expectedMixedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed");
            yield return new TestCaseData("T&(T|t)|f|T&(T|t)|t", new Queue<IToken>(expectedMixedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed");
            yield return new TestCaseData("t&(t|T)|F|t&(t|T)|T", new Queue<IToken>(expectedMixedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed");

            yield return new TestCaseData("f|(f&t)|f|f|(f&f)|f", new Queue<IToken>(expectedMixedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed");
            yield return new TestCaseData("F|(F&T)|F|F|(F&F)|F", new Queue<IToken>(expectedMixedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed");
            yield return new TestCaseData("F|(F&t)|f|F|(F&f)|f", new Queue<IToken>(expectedMixedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed");
            yield return new TestCaseData("f|(f&T)|F|f|(f&F)|F", new Queue<IToken>(expectedMixedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed");
        }
    }
}
