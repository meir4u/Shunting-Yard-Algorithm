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

namespace ShantingYardTest
{
    class PostfixFactoryTest
    {
        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCaseSource("QueueSimpleTokenData")]
        [TestCaseSource("QueueSimpleMixedTokenData")]
        [TestCaseSource("QueueSimpleTokenDataWithParentasi")]
        [TestCaseSource("QueueSimpleMixedTokenDataWithParentasi")]
        [TestCaseSource("QueueMiddleTokenDataWithParentasi")]
        [TestCaseSource("QueueMiddleMixedTokenDataWithParentasi")]
        [TestCaseSource("QueueMixedTokenDataWithParentasi")]
        [TestCaseSource("QueueMixedAndMixedTokenDataWithParentasi")]
        public void QueueTokenTypesTest(Queue<IToken> infix, Queue<IToken> expected)
        {
            var infixtokens = new PostfixFactory().Create(infix);

            Assert.That(expected.Count, Is.Not.EqualTo(0), "Expected Test case wrong!");

            while (expected.Count > 0)
            {
                Assert.That(infixtokens.Dequeue().GetType(), Is.EqualTo(expected.Dequeue().GetType()));
            }
        }

        private static IEnumerable<TestCaseData> QueueSimpleTokenData()
        {
            Queue<IToken> infixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t')
            });
            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
            });

            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t')
            });
            
            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f')
            });
            
            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
            });
            
            yield return new TestCaseData(new Queue<IToken>(infixTandT), new Queue<IToken>(postfixTandT)).SetName("Simple - 2 Same Boolean(t) with &");

            yield return new TestCaseData(new Queue<IToken>(infixFandF), new Queue<IToken>(postfixFandF)).SetName("Simple - 2 Same Boolean(f) with &");

            yield return new TestCaseData(new Queue<IToken>(infixTorT), new Queue<IToken>(postfixTorT)).SetName("Simple - 2 Same Boolean(t) with |");

            yield return new TestCaseData(new Queue<IToken>(infixForF), new Queue<IToken>(postfixForF)).SetName("Simple - 2 Same Boolean(f) with |");
           
        }

        private static IEnumerable<TestCaseData> QueueSimpleMixedTokenData()
        {
            Queue<IToken> infixTorF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
            });

            Queue<IToken> postfixTorF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixForT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t')
            });

            Queue<IToken> postfixForT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });


            Queue<IToken> infixTandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f')
            });

            Queue<IToken> postfixTandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixFandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t')
            });

            Queue<IToken> postfixFandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
            });

            
            yield return new TestCaseData(new Queue<IToken>(infixTorF), new Queue<IToken>(postfixTorF)).SetName("Simple - 2 Same Boolean(f) with |");

            yield return new TestCaseData(new Queue<IToken>(infixForT), new Queue<IToken>(postfixForT)).SetName("Simple - 2 Same Boolean(f) with |");

            yield return new TestCaseData(new Queue<IToken>(infixTandF), new Queue<IToken>(postfixTandF)).SetName("Simple - 2 Same Boolean(f) with |");

            yield return new TestCaseData(new Queue<IToken>(infixFandT), new Queue<IToken>(postfixFandT)).SetName("Simple - 2 Same Boolean(f) with |");

        }


        private static IEnumerable<TestCaseData> QueueSimpleTokenDataWithParentasi()
        {
            Queue<IToken> infixTandT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
            });

            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixFandF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
            });


            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixTorT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
            });
            
            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixForF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
            });


            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
            });


            yield return new TestCaseData(new Queue<IToken>(infixTandT), new Queue<IToken>(postfixTandT)).SetName("Simple - 2 Same Boolean(t) with &  and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixFandF), new Queue<IToken>(postfixFandF)).SetName("Simple - 2 Same Boolean(f) with & and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixTorT), new Queue<IToken>(postfixTorT)).SetName("Simple - 2 Same Boolean(t) with | and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixForF), new Queue<IToken>(postfixForF)).SetName("Simple - 2 Same Boolean(f) with | and WithParentasi");
        }


        private static IEnumerable<TestCaseData> QueueSimpleMixedTokenDataWithParentasi()
        {
            Queue<IToken> infixTandF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
            });

            Queue<IToken> postfixTandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixFandT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
            });


            Queue<IToken> postfixFandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixTorF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new ParentasiTokenFactory().Create(')'),
            });

            Queue<IToken> postfixTorF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixForT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create('('),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new ParentasiTokenFactory().Create(')'),
            });


            Queue<IToken> postfixForT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });


            yield return new TestCaseData(new Queue<IToken>(infixTandF), new Queue<IToken>(postfixTandF)).SetName("Simple - 2 Same Boolean(t) with &  and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixFandT), new Queue<IToken>(postfixFandT)).SetName("Simple - 2 Same Boolean(f) with & and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixTorF), new Queue<IToken>(postfixTorF)).SetName("Simple - 2 Same Boolean(t) with | and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixForT), new Queue<IToken>(postfixForT)).SetName("Simple - 2 Same Boolean(f) with | and WithParentasi");
        }

        private static IEnumerable<TestCaseData> QueueMiddleTokenDataWithParentasi()
        {
            Queue<IToken> infixTandT = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
            });


            Queue<IToken> infixFandF = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
            });


            Queue<IToken> infixTorT = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixForF = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
            });

            yield return new TestCaseData(new Queue<IToken>(infixTandT), new Queue<IToken>(postfixTandT)).SetName("Middle - 4 Same Boolean(t) with &  and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixFandF), new Queue<IToken>(postfixFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixTorT), new Queue<IToken>(postfixTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixForF), new Queue<IToken>(postfixForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi");
        }

        private static IEnumerable<TestCaseData> QueueMiddleMixedTokenDataWithParentasi()
        {
            Queue<IToken> infixMixedTandT = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixMixedFandF = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixMixedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixMixedTorT = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixMixedForF = new Queue<IToken>(new List<IToken>{
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
            Queue<IToken> postfixMixedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
            });


            yield return new TestCaseData(new Queue<IToken>(infixMixedTandT), new Queue<IToken>(postfixMixedTandT)).SetName("Middle - 4 Same Boolean(t) with & and WithParentasi and Mixed");

            yield return new TestCaseData(new Queue<IToken>(infixMixedFandF), new Queue<IToken>(postfixMixedFandF)).SetName("Middle - 4 Same Boolean(f) with & and WithParentasi and Mixed");

            yield return new TestCaseData(new Queue<IToken>(infixMixedTorT), new Queue<IToken>(postfixMixedTorT)).SetName("Middle - 4 Same Boolean(t) with | and WithParentasi and Mixed");

            yield return new TestCaseData(new Queue<IToken>(infixMixedForF), new Queue<IToken>(postfixMixedForF)).SetName("Middle - 4 Same Boolean(f) with | and WithParentasi and Mixed");
        }


        private static IEnumerable<TestCaseData> QueueMixedTokenDataWithParentasi()
        {
            Queue<IToken> infixTandT = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('|'),
            });


            Queue<IToken> infixFandF = new Queue<IToken>(new List<IToken>{
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


            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixTorT = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixForF = new Queue<IToken>(new List<IToken>{
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


            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
            });

            yield return new TestCaseData(new Queue<IToken>(infixTandT), new Queue<IToken>(postfixTandT)).SetName("Mixed - 8 Mixed Boolean(t) with &  and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixFandF), new Queue<IToken>(postfixFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixTorT), new Queue<IToken>(postfixTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(infixForF), new Queue<IToken>(postfixForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi");

            
        }

        private static IEnumerable<TestCaseData> QueueMixedAndMixedTokenDataWithParentasi()
        {
            Queue<IToken> infixMixedTandT = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
            });


            Queue<IToken> infixMixedFandF = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixMixedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> infixMixedTorT = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> infixMixedForF = new Queue<IToken>(new List<IToken>{
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

            Queue<IToken> postfixMixedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
            });


            yield return new TestCaseData(new Queue<IToken>(infixMixedTandT), new Queue<IToken>(postfixMixedTandT)).SetName("Mixed - 8 Mixed Boolean(t) with & and WithParentasi and Mixed");

            yield return new TestCaseData(new Queue<IToken>(infixMixedFandF), new Queue<IToken>(postfixMixedFandF)).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi and Mixed");

            yield return new TestCaseData(new Queue<IToken>(infixMixedTorT), new Queue<IToken>(postfixMixedTorT)).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi and Mixed");

            yield return new TestCaseData(new Queue<IToken>(infixMixedForF), new Queue<IToken>(postfixMixedForF)).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi and Mixed");
        }
    }
}
