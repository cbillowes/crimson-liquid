using NUnit.Framework;

namespace WordFunneller.Core.Tests
{
    [TestFixture]
    public class MostFrequentLetterCountShould : IMostFrequentTest
    {
        private ICalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new FrequentLengthCalculator(limit: 7);
        }

        [Test]
        public void Return_default_data_when_no_items_exist()
        {
            var words = new string[] { };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo(string.Empty));
            Assert.That(total, Is.EqualTo(0));
        }

        [Test]
        public void Return_first_when_no_duplicates()
        {
            var words = new[] { "hotel", "india", "juliets", "kilo", "lima", "alpha" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("juliets"));
            Assert.That(total, Is.EqualTo(1));
        }

        [Test]
        public void Return_highest_with_duplicates()
        {
            var words = new[] { "hotel", "yankies", "hotel", "yankies", "hotel" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("yankies"));
            Assert.That(total, Is.EqualTo(2));
        }

        [Test]
        public void Return_highest_ordered_with_duplicates()
        {
            var words = new[] { "hotel", "yankies", "yankies", "yankies", "yellows", "yellows", "yes", "hurry" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("yankies"));
            Assert.That(total, Is.EqualTo(3));
        }

        [Test]
        public void Return_case_insensitive_order()
        {
            var words = new[] { "Golfers", "yoyo", "golFers", "zulu", "GOLFers", "gOlFers", "golfers" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("golfers"));
            Assert.That(total, Is.EqualTo(5));
        }

        [Test]
        public void Return_the_most_frequent_word()
        {
            var words = new[] { "yellows", "yellows", "yankies" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("yellows"));
            Assert.That(total, Is.EqualTo(2));
        }
    }
}