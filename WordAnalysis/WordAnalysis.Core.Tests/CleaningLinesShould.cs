using NUnit.Framework;

namespace WordAnalysis.Core.Tests
{
    [TestFixture]
    public class CleaningLinesShould
    {
        private ICleaner _cleaner;

        [SetUp]
        public void SetUp()
        {
            _cleaner = new LineCleaner();
        }

        [Test]
        public void Trim_trailing_whitespace()
        {
            const string text = "Deadpool                    ";
            var actual = _cleaner.Clean(text);
            Assert.That(actual, Is.EqualTo(new [] { "Deadpool" }));

        }

        [Test]
        public void Remove_empty_lines()
        {
            const string text = "\r\nWolverine\r\n\r\n";
            var actual = _cleaner.Clean(text);
            Assert.That(actual, Is.EqualTo(new [] { "Wolverine" }));
        }

        [Test]
        public void Keep_straight_apostrophes_in_words_as_is()
        {
            const string text = "The hulk's turn to code";
            var actual = _cleaner.Clean(text);
            Assert.That(actual, Is.EqualTo(new []
            {
                "The",
                "hulk's",
                "turn",
                "to",
                "code",
            }));
        }

        [Test]
        public void Keep_curly_apostrophes_in_words_as_is()
        {
            const string text = "The hulk’s turn to code";
            var actual = _cleaner.Clean(text);
            Assert.That(actual, Is.EqualTo(new []
            {
                "The",
                "hulk’s",
                "turn",
                "to",
                "code",
            }));
        }

        [Test]
        public void Keep_hypenated_words_as_is()
        {
            const string text = "Spider-man";
            var actual = _cleaner.Clean(text);
            Assert.That(actual, Is.EqualTo(new [] { "Spider-man" }));
        }

        [Test]
        public void Keep_accented_characters()
        {
            const string text = "Hy het hoërskool gesê";
            var actual = _cleaner.Clean(text);
            Assert.That(actual, Is.EqualTo(new []
            {
                "Hy",
                "het",
                "hoërskool",
                "gesê",
            }));
        }

        [Test]
        public void Discard_special_characters()
        {
            const string text = "Hey! You... Are you there?";
            var actual = _cleaner.Clean(text);
            Assert.That(actual, Is.EqualTo(new []
            {
                "Hey",
                "You",
                "Are",
                "you",
                "there",
            }));
        }
    }
}
