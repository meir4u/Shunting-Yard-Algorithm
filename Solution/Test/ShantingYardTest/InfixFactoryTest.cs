using NUnit.Framework;
using ShuntingYardAlgorithm;
using ShuntingYardAlgorithm.Factory;
using ShuntingYardAlgorithm.Factory.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuntingYardAlgorithm.Extension;
using ShuntingYardAlgorithm.Base.Token.Interface;

namespace ShantingYardTest
{
    class InfixFactoryTest
    {
        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCaseSource(nameof(QueueSimpleTokenData))]
        [TestCaseSource(nameof(QueueSimpleTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMiddleTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMixedTokenDataWithParentasi))]
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
        [TestCaseSource(nameof(QueueSimpleTokenData))]
        [TestCaseSource(nameof(QueueSimpleTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMiddleTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMixedTokenDataWithParentasi))]
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


            yield return new TestCaseData("t&t", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Simple - 2: t&t", expectedTandT.PrintRawData());
            yield return new TestCaseData("T&T", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Simple - 2: T&T", expectedTandT.PrintRawData());
            yield return new TestCaseData("T&t", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Simple - 2: T&t", expectedTandT.PrintRawData());
            yield return new TestCaseData("t&T", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Simple - 2: t&T", expectedTandT.PrintRawData());

            yield return new TestCaseData("f&f", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Simple - 2: f&f", expectedFandF.PrintRawData());
            yield return new TestCaseData("F&F", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Simple - 2: F&F", expectedFandF.PrintRawData());
            yield return new TestCaseData("F&f", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Simple - 2: F&f", expectedFandF.PrintRawData());
            yield return new TestCaseData("f&F", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Simple - 2: f&F", expectedFandF.PrintRawData());

            yield return new TestCaseData("t|t", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Simple - 2: t|t", expectedTorT.PrintRawData());
            yield return new TestCaseData("T|T", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Simple - 2: T|T", expectedTorT.PrintRawData());
            yield return new TestCaseData("T|t", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Simple - 2: T|t", expectedTorT.PrintRawData());
            yield return new TestCaseData("t|T", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Simple - 2: t|T", expectedTorT.PrintRawData());

            yield return new TestCaseData("f|f", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Simple - 2: f|f", expectedForF.PrintRawData());
            yield return new TestCaseData("F|F", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Simple - 2: F|F", expectedForF.PrintRawData());
            yield return new TestCaseData("F|f", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Simple - 2: F|f", expectedForF.PrintRawData());
            yield return new TestCaseData("f|F", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Simple - 2: f|F", expectedForF.PrintRawData());
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


            yield return new TestCaseData("(t&t)", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Simple - 2 Same Boolean(t) with &  and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("(T&T)", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Simple - 2 Same Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("(T&t)", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Simple - 2 Same Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("(t&T)", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Simple - 2 Same Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());

            yield return new TestCaseData("(f&f)", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Simple - 2 Same Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("(F&F)", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Simple - 2 Same Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("(F&f)", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Simple - 2 Same Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("(f&F)", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Simple - 2 Same Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());

            yield return new TestCaseData("(t|t)", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Simple - 2 Same Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("(T|T)", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Simple - 2 Same Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("(T|t)", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Simple - 2 Same Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("(t|T)", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Simple - 2 Same Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());

            yield return new TestCaseData("(f|f)", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Simple - 2 Same Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("(F|F)", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Simple - 2 Same Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("(F|f)", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Simple - 2 Same Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("(f|F)", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Simple - 2 Same Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
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


            yield return new TestCaseData("t&(t&t)&t", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with &  and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("T&(T&T)&T", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("T&(T&t)&t", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("t&(t&T)&T", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());

            yield return new TestCaseData("f&(f&f)&f", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("F&(F&F)&F", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("F&(F&f)&f", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("f&(f&F)&F", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());

            yield return new TestCaseData("t|(t|t)|t", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("T|(T|T)|T", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("T|(T|t)|t", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("t|(t|T)|T", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());

            yield return new TestCaseData("f|(f|f)|f", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("F|(F|F)|F", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("F|(F|f)|f", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("f|(f|F)|F", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());

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


            yield return new TestCaseData("t&(t&t)|t", new Queue<IToken>(expectedMixedTandT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("T&(T&T)|T", new Queue<IToken>(expectedMixedTandT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("T&(T&t)|t", new Queue<IToken>(expectedMixedTandT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("t&(t&T)|T", new Queue<IToken>(expectedMixedTandT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());

            yield return new TestCaseData("f&(f|f)&f", new Queue<IToken>(expectedMixedFandF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed", expectedMixedFandF.PrintRawData());
            yield return new TestCaseData("F&(F|F)&F", new Queue<IToken>(expectedMixedFandF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed", expectedMixedFandF.PrintRawData());
            yield return new TestCaseData("F&(F|f)&f", new Queue<IToken>(expectedMixedFandF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed", expectedMixedFandF.PrintRawData());
            yield return new TestCaseData("f&(f|F)&F", new Queue<IToken>(expectedMixedFandF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed", expectedMixedFandF.PrintRawData());

            yield return new TestCaseData("t&(t|t)|t", new Queue<IToken>(expectedMixedTorT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed", expectedMixedTorT.PrintRawData());
            yield return new TestCaseData("T&(T|T)|T", new Queue<IToken>(expectedMixedTorT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed", expectedMixedTorT.PrintRawData());
            yield return new TestCaseData("T&(T|t)|t", new Queue<IToken>(expectedMixedTorT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed", expectedMixedTorT.PrintRawData());
            yield return new TestCaseData("t&(t|T)|T", new Queue<IToken>(expectedMixedTorT)).SetArgDisplayNames("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed", expectedMixedTorT.PrintRawData());

            yield return new TestCaseData("f|(f&f)|f", new Queue<IToken>(expectedMixedForF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed", expectedMixedForF.PrintRawData());
            yield return new TestCaseData("F|(F&F)|F", new Queue<IToken>(expectedMixedForF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed", expectedMixedForF.PrintRawData());
            yield return new TestCaseData("F|(F&f)|f", new Queue<IToken>(expectedMixedForF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed", expectedMixedForF.PrintRawData());
            yield return new TestCaseData("f|(f&F)|F", new Queue<IToken>(expectedMixedForF)).SetArgDisplayNames("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed", expectedMixedForF.PrintRawData());
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


            yield return new TestCaseData("t&(t&t)&t|t&(t&t)&f", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with &  and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("T&(T&T)&T|T&(T&T)&F", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("T&(T&t)&t|T&(T&t)&f", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());
            yield return new TestCaseData("t&(t&T)&T|t&(t&T)&F", new Queue<IToken>(expectedTandT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with & and WithParentasi", expectedTandT.PrintRawData());

            yield return new TestCaseData("f&(f&f)&f|f&(f&t)&f", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("F&(F&F)&F|F&(F&T)&F", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("F&(F&f)&f|F&(F&t)&f", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());
            yield return new TestCaseData("f&(f&F)&F|f&(f&T)&F", new Queue<IToken>(expectedFandF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with & and WithParentasi", expectedFandF.PrintRawData());

            yield return new TestCaseData("t|(t|f)|t&t|(t|t)|t", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("T|(T|F)|T&T|(T|T)|T", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("T|(T|f)|t&T|(T|t)|t", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());
            yield return new TestCaseData("t|(t|F)|T&t|(t|T)|T", new Queue<IToken>(expectedTorT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with | and WithParentasi", expectedTorT.PrintRawData());

            yield return new TestCaseData("t|(f|f)|f&f|(f|f)|f", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("T|(F|F)|F&F|(F|F)|F", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("T|(F|f)|f&F|(F|f)|f", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());
            yield return new TestCaseData("t|(f|F)|F&f|(f|F)|F", new Queue<IToken>(expectedForF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with | and WithParentasi", expectedForF.PrintRawData());

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


            yield return new TestCaseData("t&(t&t)|t|t&(t&f)|t", new Queue<IToken>(expectedMixedTandT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("T&(T&T)|T|T&(T&F)|T", new Queue<IToken>(expectedMixedTandT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("T&(T&t)|t|T&(T&f)|t", new Queue<IToken>(expectedMixedTandT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("t&(t&T)|T|t&(t&F)|T", new Queue<IToken>(expectedMixedTandT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());

            yield return new TestCaseData("f&(f|f)&f&f&(f|f)&t", new Queue<IToken>(expectedMixedFandF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("F&(F|F)&F&F&(F|F)&T", new Queue<IToken>(expectedMixedFandF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("F&(F|f)&f&F&(F|f)&t", new Queue<IToken>(expectedMixedFandF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("f&(f|F)&F&f&(f|F)&T", new Queue<IToken>(expectedMixedFandF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());

            yield return new TestCaseData("t&(t|t)|f|t&(t|t)|t", new Queue<IToken>(expectedMixedTorT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("T&(T|T)|F|T&(T|T)|T", new Queue<IToken>(expectedMixedTorT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("T&(T|t)|f|T&(T|t)|t", new Queue<IToken>(expectedMixedTorT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("t&(t|T)|F|t&(t|T)|T", new Queue<IToken>(expectedMixedTorT)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());

            yield return new TestCaseData("f|(f&t)|f|f|(f&f)|f", new Queue<IToken>(expectedMixedForF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("F|(F&T)|F|F|(F&F)|F", new Queue<IToken>(expectedMixedForF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("F|(F&t)|f|F|(F&f)|f", new Queue<IToken>(expectedMixedForF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
            yield return new TestCaseData("f|(f&T)|F|f|(f&F)|F", new Queue<IToken>(expectedMixedForF)).SetArgDisplayNames("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed", expectedMixedTandT.PrintRawData());
        }
    }
}
