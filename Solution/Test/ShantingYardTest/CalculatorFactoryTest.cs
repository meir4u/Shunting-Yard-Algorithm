﻿using NUnit.Framework;
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
        [TestCaseSource(nameof(QueueSimpleTokenData))]
        [TestCaseSource(nameof(QueueSimpleMixedTokenData))]
        [TestCaseSource(nameof(QueueMiddleTokenData))]
        [TestCaseSource(nameof(QueueMiddleMixedTokenData))]
        [TestCaseSource(nameof(QueueMixedTokenData))]
        [TestCaseSource(nameof(QueueMixedAndMixedTokenData))]
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
            
            yield return new TestCaseData(new Queue<IToken>(postfixTandT), true).SetArgDisplayNames("Simple", postfixTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixFandF), false).SetArgDisplayNames("Simple", postfixFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixTorT), true).SetArgDisplayNames("Simple", postfixTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixForF), false).SetArgDisplayNames("Simple", postfixForF.PrintRawData());
           
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

            
            yield return new TestCaseData(new Queue<IToken>(postfixTorF), true).SetArgDisplayNames("Simple", postfixTorF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixForT), true).SetArgDisplayNames("Simple", postfixForT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixTandF), false).SetArgDisplayNames("Simple", postfixTandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixFandT), false).SetArgDisplayNames("Simple", postfixFandT.PrintRawData());

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

            yield return new TestCaseData(new Queue<IToken>(postfixTandT), true).SetArgDisplayNames("Middle", postfixTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixFandF), false).SetArgDisplayNames("Middle", postfixFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixTorT), true).SetArgDisplayNames("Middle", postfixTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixForF), false).SetArgDisplayNames("Middle", postfixForF.PrintRawData());
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


            yield return new TestCaseData(new Queue<IToken>(postfixMixedTandT), true).SetArgDisplayNames("Middle", postfixMixedTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixMixedFandF), false).SetArgDisplayNames("Middle", postfixMixedFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixMixedTorT), true).SetArgDisplayNames("Middle", postfixMixedTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixMixedForF), false).SetArgDisplayNames("Middle", postfixMixedForF.PrintRawData());
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

            yield return new TestCaseData(new Queue<IToken>(postfixTandT), true).SetArgDisplayNames("Mixed", postfixTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixFandF), false).SetArgDisplayNames("Mixed", postfixFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixTorT), true).SetArgDisplayNames("Mixed", postfixTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixForF), true).SetArgDisplayNames("Mixed", postfixForF.PrintRawData());

            
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


            yield return new TestCaseData(new Queue<IToken>(postfixMixedTandT), true).SetArgDisplayNames("Mixed", postfixMixedTandT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixMixedFandF), false).SetArgDisplayNames("Mixed", postfixMixedFandF.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixMixedTorT), true).SetArgDisplayNames("Mixed", postfixMixedTorT.PrintRawData());

            yield return new TestCaseData(new Queue<IToken>(postfixMixedForF), false).SetArgDisplayNames("Mixed", postfixMixedForF.PrintRawData());
        }
    }
}
