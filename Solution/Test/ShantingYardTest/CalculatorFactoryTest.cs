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
    class CalculatorFactoryTest
    {
        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCaseSource("QueueSimpleTokenData")]
        [TestCaseSource("QueueSimpleMixedTokenData")]
        [TestCaseSource("QueueMiddleTokenData")]
        [TestCaseSource("QueueMiddleMixedTokenData")]
        [TestCaseSource("QueueMixedTokenData")]
        [TestCaseSource("QueueMixedAndMixedTokenData")]
        public void QueueTokenTypesTest(Queue<IToken> postfix, bool expected)
        {
            bool calculatedResult = (bool)new CalculatorFactory().Calculate(postfix);

            Assert.That(calculatedResult, Is.EqualTo(expected), "Expected Test case wrong!");

        }

        private static IEnumerable<TestCaseData> QueueSimpleTokenData()
        {
            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> postfixFandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
            });
                        
            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });
                        
            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
            });
            
            yield return new TestCaseData(new Queue<IToken>(postfixTandT), true).SetName("Simple - 2 Same Boolean(t) with &");

            yield return new TestCaseData(new Queue<IToken>(postfixFandF), false).SetName("Simple - 2 Same Boolean(f) with &");

            yield return new TestCaseData(new Queue<IToken>(postfixTorT), true).SetName("Simple - 2 Same Boolean(t) with |");

            yield return new TestCaseData(new Queue<IToken>(postfixForF), false).SetName("Simple - 2 Same Boolean(f) with |");
           
        }

        private static IEnumerable<TestCaseData> QueueSimpleMixedTokenData()
        {
            Queue<IToken> postfixTorF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> postfixForT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });

            Queue<IToken> postfixTandF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('&'),
            });

            Queue<IToken> postfixFandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
            });

            
            yield return new TestCaseData(new Queue<IToken>(postfixTorF), true).SetName("Simple - 2 Same Boolean(f) with |");

            yield return new TestCaseData(new Queue<IToken>(postfixForT), true).SetName("Simple - 2 Same Boolean(f) with |");

            yield return new TestCaseData(new Queue<IToken>(postfixTandF), false).SetName("Simple - 2 Same Boolean(f) with |");

            yield return new TestCaseData(new Queue<IToken>(postfixFandT), false).SetName("Simple - 2 Same Boolean(f) with |");

        }

        private static IEnumerable<TestCaseData> QueueMiddleTokenData()
        {
            Queue<IToken> postfixTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
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

            Queue<IToken> postfixTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
            });


            Queue<IToken> postfixForF = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('|'),
                new BooleanTokenFactory().Create('f'),
                new OperatorTokenFactory().Create('|'),
            });

            yield return new TestCaseData(new Queue<IToken>(postfixTandT), true).SetName("Middle - 4 Same Boolean(t) with & ");

            yield return new TestCaseData(new Queue<IToken>(postfixFandF), false).SetName("Middle - 4 Same Boolean(f) with & ");

            yield return new TestCaseData(new Queue<IToken>(postfixTorT), true).SetName("Middle - 4 Same Boolean(t) with | ");

            yield return new TestCaseData(new Queue<IToken>(postfixForF), false).SetName("Middle - 4 Same Boolean(f) with | ");
        }

        private static IEnumerable<TestCaseData> QueueMiddleMixedTokenData()
        {
            Queue<IToken> postfixMixedTandT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('&'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
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

            Queue<IToken> postfixMixedTorT = new Queue<IToken>(new List<IToken>{
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
                new OperatorTokenFactory().Create('&'),
                new BooleanTokenFactory().Create('t'),
                new OperatorTokenFactory().Create('|'),
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


            yield return new TestCaseData(new Queue<IToken>(postfixMixedTandT), true).SetName("Middle - 4 Same Boolean(t) with & and Mixed");

            yield return new TestCaseData(new Queue<IToken>(postfixMixedFandF), false).SetName("Middle - 4 Same Boolean(f) with & and Mixed");

            yield return new TestCaseData(new Queue<IToken>(postfixMixedTorT), true).SetName("Middle - 4 Same Boolean(t) with | and Mixed");

            yield return new TestCaseData(new Queue<IToken>(postfixMixedForF), false).SetName("Middle - 4 Same Boolean(f) with | and Mixed");
        }


        private static IEnumerable<TestCaseData> QueueMixedTokenData()
        {
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

            yield return new TestCaseData(new Queue<IToken>(postfixTandT), true).SetName("Mixed - 8 Mixed Boolean(t) with &  and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(postfixFandF), false).SetName("Mixed - 8 Mixed Boolean(f) with & and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(postfixTorT), true).SetName("Mixed - 8 Mixed Boolean(t) with | and WithParentasi");

            yield return new TestCaseData(new Queue<IToken>(postfixForF), true).SetName("Mixed - 8 Mixed Boolean(f) with | and WithParentasi");

            
        }

        private static IEnumerable<TestCaseData> QueueMixedAndMixedTokenData()
        {
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


            yield return new TestCaseData(new Queue<IToken>(postfixMixedTandT), true).SetName("Mixed - 8 Mixed Boolean(t) with & and Mixed");

            yield return new TestCaseData(new Queue<IToken>(postfixMixedFandF), false).SetName("Mixed - 8 Mixed Boolean(f) with & and Mixed");

            yield return new TestCaseData(new Queue<IToken>(postfixMixedTorT), true).SetName("Mixed - 8 Mixed Boolean(t) with | and Mixed");

            yield return new TestCaseData(new Queue<IToken>(postfixMixedForF), false).SetName("Mixed - 8 Mixed Boolean(f) with | and Mixed");
        }
    }
}
