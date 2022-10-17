using NUnit.Framework;
using ShuntingYardAlgorithm;
using ShuntingYardAlgorithm.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuntingYardAlgorithm.Extension;
using ShuntingYardAlgorithm.Base.Token.Interface;
using ShuntingYardAlgorithm.Parser.Factory.Token;

namespace ShantingYardTest
{
    class PostfixFactoryTest : Base
    {
        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCaseSource(nameof(QueueSimpleTokenData))]
        [TestCaseSource(nameof(QueueSimpleMixedTokenData))]
        [TestCaseSource(nameof(QueueSimpleTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueSimpleMixedTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMiddleTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMiddleMixedTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMixedTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMixedAndMixedTokenDataWithParentasi))]
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
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE)
            });
            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
            });

            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE)
            });
            
            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE)
            });
            
            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
            });
            
            yield return new TestCaseData(new Queue<IToken>(infixTandT), new Queue<IToken>(postfixTandT)).SetArgDisplayNames(infixTandT.PrintRawData(), postfixTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixFandF), new Queue<IToken>(postfixFandF)).SetArgDisplayNames(infixFandF.PrintRawData(), postfixFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixTorT), new Queue<IToken>(postfixTorT)).SetArgDisplayNames(infixTorT.PrintRawData(), postfixTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixForF), new Queue<IToken>(postfixForF)).SetArgDisplayNames(infixForF.PrintRawData(), postfixForF.PrintRawData());
           
        }

        private static IEnumerable<TestCaseData> QueueSimpleMixedTokenData()
        {
            Queue<IToken> infixTorF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
            });

            Queue<IToken> postfixTorF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixForT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE)
            });

            Queue<IToken> postfixForT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
            });


            Queue<IToken> infixTandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE)
            });

            Queue<IToken> postfixTandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixFandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE)
            });

            Queue<IToken> postfixFandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
            });

            
            yield return new TestCaseData(new Queue<IToken>(infixTorF), new Queue<IToken>(postfixTorF)).SetArgDisplayNames(infixTorF.PrintRawData(), postfixTorF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixForT), new Queue<IToken>(postfixForT)).SetArgDisplayNames(infixForT.PrintRawData(), postfixForT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixTandF), new Queue<IToken>(postfixTandF)).SetArgDisplayNames(infixTandF.PrintRawData(), postfixTandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixFandT), new Queue<IToken>(postfixFandT)).SetArgDisplayNames(infixFandT.PrintRawData(), postfixFandT.PrintRawData());

        }


        private static IEnumerable<TestCaseData> QueueSimpleTokenDataWithParentasi()
        {
            Queue<IToken> infixTandT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
            });

            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixFandF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
            });


            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixTorT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
            });
            
            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixForF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
            });


            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
            });


            yield return new TestCaseData(new Queue<IToken>(infixTandT), new Queue<IToken>(postfixTandT)).SetArgDisplayNames(infixTandT.PrintRawData(), postfixTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixFandF), new Queue<IToken>(postfixFandF)).SetArgDisplayNames(infixFandF.PrintRawData(), postfixFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixTorT), new Queue<IToken>(postfixTorT)).SetArgDisplayNames(infixTorT.PrintRawData(), postfixTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixForF), new Queue<IToken>(postfixForF)).SetArgDisplayNames(infixForF.PrintRawData(), postfixForF.PrintRawData());
        }


        private static IEnumerable<TestCaseData> QueueSimpleMixedTokenDataWithParentasi()
        {
            Queue<IToken> infixTandF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
            });

            Queue<IToken> postfixTandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixFandT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
            });


            Queue<IToken> postfixFandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixTorF = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
            });

            Queue<IToken> postfixTorF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixForT = new Queue<IToken>(new List<IToken>{
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
            });


            Queue<IToken> postfixForT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
            });


            yield return new TestCaseData(new Queue<IToken>(infixTandF), new Queue<IToken>(postfixTandF)).SetArgDisplayNames(infixTandF.PrintRawData(), postfixTandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixFandT), new Queue<IToken>(postfixFandT)).SetArgDisplayNames(infixFandT.PrintRawData(), postfixFandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixTorF), new Queue<IToken>(postfixTorF)).SetArgDisplayNames(infixTorF.PrintRawData(), postfixTorF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixForT), new Queue<IToken>(postfixForT)).SetArgDisplayNames(infixForT.PrintRawData(), postfixForT.PrintRawData());
        }

        private static IEnumerable<TestCaseData> QueueMiddleTokenDataWithParentasi()
        {
            Queue<IToken> infixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
            });

            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
            });


            Queue<IToken> infixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
            });

            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
            });


            Queue<IToken> infixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
            });

            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
            });

            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
            });

            yield return new TestCaseData(new Queue<IToken>(infixTandT), new Queue<IToken>(postfixTandT)).SetArgDisplayNames(infixTandT.PrintRawData(), postfixTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixFandF), new Queue<IToken>(postfixFandF)).SetArgDisplayNames(infixFandF.PrintRawData(), postfixFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixTorT), new Queue<IToken>(postfixTorT)).SetArgDisplayNames(infixTorT.PrintRawData(), postfixTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixForF), new Queue<IToken>(postfixForF)).SetArgDisplayNames(infixForF.PrintRawData(), postfixForF.PrintRawData());
        }

        private static IEnumerable<TestCaseData> QueueMiddleMixedTokenDataWithParentasi()
        {
            Queue<IToken> infixMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
            });

            Queue<IToken> postfixMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixMixedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
            });

            Queue<IToken> postfixMixedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
            });

            Queue<IToken> postfixMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixMixedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
            });
            Queue<IToken> postfixMixedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
            });


            yield return new TestCaseData(new Queue<IToken>(infixMixedTandT), new Queue<IToken>(postfixMixedTandT)).SetArgDisplayNames(infixMixedTandT.PrintRawData(), postfixMixedTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixMixedFandF), new Queue<IToken>(postfixMixedFandF)).SetArgDisplayNames(infixMixedFandF.PrintRawData(), postfixMixedFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixMixedTorT), new Queue<IToken>(postfixMixedTorT)).SetArgDisplayNames(infixMixedTorT.PrintRawData(), postfixMixedTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixMixedForF), new Queue<IToken>(postfixMixedForF)).SetArgDisplayNames(infixMixedForF.PrintRawData(), postfixMixedForF.PrintRawData());
        }


        private static IEnumerable<TestCaseData> QueueMixedTokenDataWithParentasi()
        {
            Queue<IToken> infixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
            });

            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(OR),
            });


            Queue<IToken> infixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
            });


            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
            });

            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
            });


            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
            });

            yield return new TestCaseData(new Queue<IToken>(infixTandT), new Queue<IToken>(postfixTandT)).SetArgDisplayNames(infixTandT.PrintRawData(), postfixTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixFandF), new Queue<IToken>(postfixFandF)).SetArgDisplayNames(infixFandF.PrintRawData(), postfixFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixTorT), new Queue<IToken>(postfixTorT)).SetArgDisplayNames(infixTorT.PrintRawData(), postfixTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixForF), new Queue<IToken>(postfixForF)).SetArgDisplayNames(infixForF.PrintRawData(), postfixForF.PrintRawData());

            
        }

        private static IEnumerable<TestCaseData> QueueMixedAndMixedTokenDataWithParentasi()
        {
            Queue<IToken> infixMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
            });

            Queue<IToken> postfixMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
            });


            Queue<IToken> infixMixedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
            });

            Queue<IToken> postfixMixedFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
                new OperatorTokenFactory().Create(AND),
            });

            Queue<IToken> infixMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(TRUE),
            });

            Queue<IToken> postfixMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
            });

            Queue<IToken> infixMixedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(TRUE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new ParentasiTokenFactory().Create(OPEN_PARENTASI),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new ParentasiTokenFactory().Create(CLOSE_PARENTASI),
                new OperatorTokenFactory().Create(OR),
                new BooleanTokenFactory().Create(FALSE),
            });

            Queue<IToken> postfixMixedForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(TRUE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(AND),
                new BooleanTokenFactory().Create(FALSE),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
                new OperatorTokenFactory().Create(OR),
            });


            yield return new TestCaseData(new Queue<IToken>(infixMixedTandT), new Queue<IToken>(postfixMixedTandT)).SetArgDisplayNames(infixMixedTandT.PrintRawData(), postfixMixedTandT.PrintRawData());

           yield return new TestCaseData(new Queue<IToken>(infixMixedFandF), new Queue<IToken>(postfixMixedFandF)).SetArgDisplayNames(infixMixedFandF.PrintRawData(), postfixMixedFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixMixedTorT), new Queue<IToken>(postfixMixedTorT)).SetArgDisplayNames(infixMixedTorT.PrintRawData(), postfixMixedTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(infixMixedForF), new Queue<IToken>(postfixMixedForF)).SetArgDisplayNames(infixMixedForF.PrintRawData(), postfixMixedForF.PrintRawData());
        }
    }
}
