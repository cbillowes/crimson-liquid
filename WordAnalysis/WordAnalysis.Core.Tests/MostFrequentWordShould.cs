using System;
using NUnit.Framework;

namespace WordAnalysis.Core.Tests
{
    [TestFixture]
    public class MostFrequentWordShould: IMostFrequentTest
    {
        private ICalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new FrequentWordCalculator();
        }

        [Test]
        public void Be_the_first_word_with_highest_occurrance()
        {
            var words = new [] { "hello", "goodbye", "hello", "goodbye", "hello" };
            var actual = _calculator.Calculate(words);
            Assert.That(actual.word, Is.EqualTo("hello"));
            Assert.That(actual.total, Is.EqualTo(3));
        }

        [Test]
        public void Be_the_first_word_in_with_highest_occurrance_and_multiple_words_of_the_same_occurance()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Be_ordered_by_word_ascending()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Be_ordered_regardless_of_case()
        {
            throw new NotImplementedException();
        }
    }
}
