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
        public void Return_default_data_when_no_items_exist()
        {
            var words = new string [] {};
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo(string.Empty));
            Assert.That(total, Is.EqualTo(0));
        }

        [Test]
        public void Return_first_when_no_duplicates()
        {
            var words = new [] { "hotel", "india", "juliet", "kilo", "lima", "alpha" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("alpha"));
            Assert.That(total, Is.EqualTo(1));
        }

        [Test]
        public void Return_highest_with_duplicates()
        {
            var words = new [] { "hotel", "yankie", "hotel", "yankie", "hotel" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("hotel"));
            Assert.That(total, Is.EqualTo(3));
        }

        [Test]
        public void Return_highest_ordered_with_duplicates()
        {
            var words = new [] { "hotel", "yankie", "hotel", "yankie", "hotel", "hotel", "yankie", "yankie" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("hotel"));
            Assert.That(total, Is.EqualTo(4));
        }

        [Test]
        public void Return_case_insensitive_order()
        {
            var words = new [] { "Golf", "yankie", "golF", "zulu", "GOLF", "gOlF", "golf" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("golf"));
            Assert.That(total, Is.EqualTo(5));
        }
    }
}
