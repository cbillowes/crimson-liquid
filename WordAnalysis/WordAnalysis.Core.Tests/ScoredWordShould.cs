using NUnit.Framework;

namespace WordAnalysis.Core.Tests
{
    public class ScoredWordShould
    {
        private ICalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ScrabbleHighestScoreCalculator();
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
        public void Calculate_score_for_word()
        {
            var words = new [] { "zoolander" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("zoolander"));
            Assert.That(total, Is.EqualTo(19));
        }

        [Test]
        public void Return_word_with_highest_score()
        {
            var words = new [] { "whiskey", "xray", "yankie", "zulu" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("whiskey"));
            Assert.That(total, Is.EqualTo(20));
        }

        [Test]
        public void Order_list_ascending()
        {
            var words = new [] { "u", "o", "i", "e", "a" };
            var (word, score) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("a"));
            Assert.That(score, Is.EqualTo(1));
        }

        [Test]
        public void Not_be_case_sensitive()
        {
            var words = new [] { "ZOOLANDER" };
            var (word, total) = _calculator.Calculate(words);
            Assert.That(word, Is.EqualTo("ZOOLANDER"));
            Assert.That(total, Is.EqualTo(19));
        }
    }
}
