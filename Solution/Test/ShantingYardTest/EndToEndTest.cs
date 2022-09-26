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
    class EndToEndTest
    {
        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCaseSource(nameof(QueueSimpleTokenData))]
        [TestCaseSource(nameof(QueueSimpleTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMiddleTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMiddleTokenMixedDataWithParentas))]
        [TestCaseSource(nameof(QueueMixedTokenDataWithParentasi))]
        [TestCaseSource(nameof(QueueMixedTokenMixedDataWithParentasi))]
        public void MainTest(string rawData, bool expected)
        {
            bool result = new SYAlgorithm().Calculate(rawData);

            Assert.That(result, Is.EqualTo(expected), "result Test case wrong!");
        }

        private static IEnumerable<TestCaseData> QueueSimpleTokenData()
        {
            yield return new TestCaseData("t&t", true).SetName("Simple - 2: t&t");
            yield return new TestCaseData("T&T", true).SetName("Simple - 2: T&T");
            yield return new TestCaseData("T&t", true).SetName("Simple - 2: T&t");
            yield return new TestCaseData("t&T", true).SetName("Simple - 2: t&T");

            yield return new TestCaseData("f&f", false).SetName("Simple - 2: f&f");
            yield return new TestCaseData("F&F", false).SetName("Simple - 2: F&F");
            yield return new TestCaseData("F&f", false).SetName("Simple - 2: F&f");
            yield return new TestCaseData("f&F", false).SetName("Simple - 2: f&F");

            yield return new TestCaseData("t|t", true).SetName("Simple - 2: t|t");
            yield return new TestCaseData("T|T", true).SetName("Simple - 2: T|T");
            yield return new TestCaseData("T|t", true).SetName("Simple - 2: T|t");
            yield return new TestCaseData("t|T", true).SetName("Simple - 2: t|T");

            yield return new TestCaseData("f|f", false).SetName("Simple - 2: f|f");
            yield return new TestCaseData("F|F", false).SetName("Simple - 2: F|F");
            yield return new TestCaseData("F|f", false).SetName("Simple - 2: F|f");
            yield return new TestCaseData("f|F", false).SetName("Simple - 2: f|F");
        }
        
        private static IEnumerable<TestCaseData> QueueSimpleTokenDataWithParentasi()
        {
            yield return new TestCaseData("(t&t)", true).SetName("Simple - 2: (t&t)");
            yield return new TestCaseData("(T&T)", true).SetName("Simple - 2: (T&T)");
            yield return new TestCaseData("(T&t)", true).SetName("Simple - 2: (T&t)");
            yield return new TestCaseData("(t&T)", true).SetName("Simple - 2: (t&T)");

            yield return new TestCaseData("(f&f)", false).SetName("Simple - 2: (f&f)");
            yield return new TestCaseData("(F&F)", false).SetName("Simple - 2: (F&F)");
            yield return new TestCaseData("(F&f)", false).SetName("Simple - 2: (F&f)");
            yield return new TestCaseData("(f&F)", false).SetName("Simple - 2: (f&F)");

            yield return new TestCaseData("(t|t)", true).SetName("Simple - 2: (t|t)");
            yield return new TestCaseData("(T|T)", true).SetName("Simple - 2: (T|T)");
            yield return new TestCaseData("(T|t)", true).SetName("Simple - 2: (T|t)");
            yield return new TestCaseData("(t|T)", true).SetName("Simple - 2: (t|T)");

            yield return new TestCaseData("(f|f)", false).SetName("Simple - 2: (f|f)");
            yield return new TestCaseData("(F|F)", false).SetName("Simple - 2: (F|F)");
            yield return new TestCaseData("(F|f)", false).SetName("Simple - 2: (F|f)");
            yield return new TestCaseData("(f|F)", false).SetName("Simple - 2: (f|F)");
        }

        private static IEnumerable<TestCaseData> QueueMiddleTokenDataWithParentasi()
        {
            yield return new TestCaseData("t&(t&t)&t", true).SetName("Middle - 4: t&(t&t)&t");
            yield return new TestCaseData("T&(T&T)&T", true).SetName("Middle - 4: T&(T&T)&T");
            yield return new TestCaseData("T&(T&t)&t", true).SetName("Middle - 4: T&(T&t)&t");
            yield return new TestCaseData("t&(t&T)&T", true).SetName("Middle - 4: t&(t&T)&T");

            yield return new TestCaseData("f&(f&f)&f", false).SetName("Middle - 4: f&(f&f)&f");
            yield return new TestCaseData("F&(F&F)&F", false).SetName("Middle - 4: F&(F&F)&F");
            yield return new TestCaseData("F&(F&f)&f", false).SetName("Middle - 4: F&(F&f)&f");
            yield return new TestCaseData("f&(f&F)&F", false).SetName("Middle - 4: f&(f&F)&F");

            yield return new TestCaseData("t|(t|t)|t", true).SetName("Middle - 4: t|(t|t)|t");
            yield return new TestCaseData("T|(T|T)|T", true).SetName("Middle - 4: T|(T|T)|T");
            yield return new TestCaseData("T|(T|t)|t", true).SetName("Middle - 4: T|(T|t)|t");
            yield return new TestCaseData("t|(t|T)|T", true).SetName("Middle - 4: t|(t|T)|T");

            yield return new TestCaseData("f|(f|f)|f", false).SetName("Middle - 4: f|(f|f)|f");
            yield return new TestCaseData("F|(F|F)|F", false).SetName("Middle - 4: F|(F|F)|F");
            yield return new TestCaseData("F|(F|f)|f", false).SetName("Middle - 4: F|(F|f)|f");
            yield return new TestCaseData("f|(f|F)|F", false).SetName("Middle - 4: f|(f|F)|F");
        }

        private static IEnumerable<TestCaseData> QueueMiddleTokenMixedDataWithParentas()
        {
            yield return new TestCaseData("t&(t&t)|t", true).SetName("Middle Mixed- 4: t&(t&t)|t");
            yield return new TestCaseData("T&(T&T)|T", true).SetName("Middle Mixed- 4: T&(T&T)|T");
            yield return new TestCaseData("T&(T&t)|t", true).SetName("Middle Mixed- 4: T&(T&t)|t");
            yield return new TestCaseData("t&(t&T)|T", true).SetName("Middle Mixed- 4: t&(t&T)|T");

            yield return new TestCaseData("f&(f|f)&f", false).SetName("Middle Mixed- 4: f&(f|f)&f");
            yield return new TestCaseData("F&(F|F)&F", false).SetName("Middle Mixed- 4: F&(F|F)&F");
            yield return new TestCaseData("F&(F|f)&f", false).SetName("Middle Mixed- 4: F&(F|f)&f");
            yield return new TestCaseData("f&(f|F)&F", false).SetName("Middle Mixed- 4: f&(f|F)&F");

            yield return new TestCaseData("t&(t|t)|t", true).SetName("Middle Mixed- 4: t&(t|t)|t");
            yield return new TestCaseData("T&(T|T)|T", true).SetName("Middle Mixed- 4: T&(T|T)|T");
            yield return new TestCaseData("T&(T|t)|t", true).SetName("Middle Mixed- 4: T&(T|t)|t");
            yield return new TestCaseData("t&(t|T)|T", true).SetName("Middle Mixed- 4: t&(t|T)|T");

            yield return new TestCaseData("f|(f&f)|f", false).SetName("Middle Mixed- 4: f|(f&f)|f");
            yield return new TestCaseData("F|(F&F)|F", false).SetName("Middle Mixed- 4: F|(F&F)|F");
            yield return new TestCaseData("F|(F&f)|f", false).SetName("Middle Mixed- 4: F|(F&f)|f");
            yield return new TestCaseData("f|(f&F)|F", false).SetName("Middle Mixed- 4: f|(f&F)|F");
        }

        private static IEnumerable<TestCaseData> QueueMixedTokenDataWithParentasi()
        {
            yield return new TestCaseData("t&(t&t)&t|t&(t&t)&f", true).SetName("Mixed - 8 Mixed: t&(t&t)&t|t&(t&t)&f");
            yield return new TestCaseData("T&(T&T)&T|T&(T&T)&F", true).SetName("Mixed - 8 Mixed: T&(T&T)&T|T&(T&T)&F");
            yield return new TestCaseData("T&(T&t)&t|T&(T&t)&f", true).SetName("Mixed - 8 Mixed: T&(T&t)&t|T&(T&t)&f");
            yield return new TestCaseData("t&(t&T)&T|t&(t&T)&F", true).SetName("Mixed - 8 Mixed: t&(t&T)&T|t&(t&T)&F");

            yield return new TestCaseData("f&(f&f)&f|f&(f&t)&f", false).SetName("Mixed - 8 Mixed: f&(f&f)&f|f&(f&t)&f");
            yield return new TestCaseData("F&(F&F)&F|F&(F&T)&F", false).SetName("Mixed - 8 Mixed: F&(F&F)&F|F&(F&T)&F");
            yield return new TestCaseData("F&(F&f)&f|F&(F&t)&f", false).SetName("Mixed - 8 Mixed: F&(F&f)&f|F&(F&t)&f");
            yield return new TestCaseData("f&(f&F)&F|f&(f&T)&F", false).SetName("Mixed - 8 Mixed: f&(f&F)&F|f&(f&T)&F");

            yield return new TestCaseData("t|(t|f)|t&t|(t|t)|t", true).SetName("Mixed - 8 Mixed: t|(t|f)|t&t|(t|t)|t");
            yield return new TestCaseData("T|(T|F)|T&T|(T|T)|T", true).SetName("Mixed - 8 Mixed: T|(T|F)|T&T|(T|T)|T");
            yield return new TestCaseData("T|(T|f)|t&T|(T|t)|t", true).SetName("Mixed - 8 Mixed: T|(T|f)|t&T|(T|t)|t");
            yield return new TestCaseData("t|(t|F)|T&t|(t|T)|T", true).SetName("Mixed - 8 Mixed: t|(t|F)|T&t|(t|T)|T");

            yield return new TestCaseData("t|(f|f)|f&f|(f|f)|f", true).SetName("Mixed - 8 Mixed: t|(f|f)|f&f|(f|f)|f");
            yield return new TestCaseData("T|(F|F)|F&F|(F|F)|F", true).SetName("Mixed - 8 Mixed: T|(F|F)|F&F|(F|F)|F");
            yield return new TestCaseData("T|(F|f)|f&F|(F|f)|f", true).SetName("Mixed - 8 Mixed: T|(F|f)|f&F|(F|f)|f");
            yield return new TestCaseData("t|(f|F)|F&f|(f|F)|F", true).SetName("Mixed - 8 Mixed: t|(f|F)|F&f|(f|F)|F");
        }

        private static IEnumerable<TestCaseData> QueueMixedTokenMixedDataWithParentasi()
        {
            yield return new TestCaseData("t&(t&t)|t|t&(t&f)|t", true).SetName("Mixed - 8 Mixed: t&(t&t)|t|t&(t&f)|t");
            yield return new TestCaseData("T&(T&T)|T|T&(T&F)|T", true).SetName("Mixed - 8 Mixed: T&(T&T)|T|T&(T&F)|T");
            yield return new TestCaseData("T&(T&t)|t|T&(T&f)|t", true).SetName("Mixed - 8 Mixed: T&(T&t)|t|T&(T&f)|t");
            yield return new TestCaseData("t&(t&T)|T|t&(t&F)|T", true).SetName("Mixed - 8 Mixed: t&(t&T)|T|t&(t&F)|T");

            yield return new TestCaseData("f&(f|f)&f&f&(f|f)&t", false).SetName("Mixed - 8 Mixed: f&(f|f)&f&f&(f|f)&t");
            yield return new TestCaseData("F&(F|F)&F&F&(F|F)&T", false).SetName("Mixed - 8 Mixed: F&(F|F)&F&F&(F|F)&T");
            yield return new TestCaseData("F&(F|f)&f&F&(F|f)&t", false).SetName("Mixed - 8 Mixed: F&(F|f)&f&F&(F|f)&t");
            yield return new TestCaseData("f&(f|F)&F&f&(f|F)&T", false).SetName("Mixed - 8 Mixed: f&(f|F)&F&f&(f|F)&T");

            yield return new TestCaseData("t&(t|t)|f|t&(t|t)|t", true).SetName("Mixed - 8 Mixed: t&(t|t)|f|t&(t|t)|t");
            yield return new TestCaseData("T&(T|T)|F|T&(T|T)|T", true).SetName("Mixed - 8 Mixed: T&(T|T)|F|T&(T|T)|T");
            yield return new TestCaseData("T&(T|t)|f|T&(T|t)|t", true).SetName("Mixed - 8 Mixed: T&(T|t)|f|T&(T|t)|t");
            yield return new TestCaseData("t&(t|T)|F|t&(t|T)|T", true).SetName("Mixed - 8 Mixed: t&(t|T)|F|t&(t|T)|T");

            yield return new TestCaseData("f|(f&t)|f|f|(f&f)|f", false).SetName("Mixed - 8 Mixed: f|(f&t)|f|f|(f&f)|f");
            yield return new TestCaseData("F|(F&T)|F|F|(F&F)|F", false).SetName("Mixed - 8 Mixed: F|(F&T)|F|F|(F&F)|F");
            yield return new TestCaseData("F|(F&t)|f|F|(F&f)|f", false).SetName("Mixed - 8 Mixed: F|(F&t)|f|F|(F&f)|f");
            yield return new TestCaseData("f|(f&T)|F|f|(f&F)|F", false).SetName("Mixed - 8 Mixed: f|(f&T)|F|f|(f&F)|F");
        }

    }
}
