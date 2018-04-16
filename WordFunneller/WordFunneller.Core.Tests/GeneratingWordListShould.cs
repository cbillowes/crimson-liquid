using System.IO;
using NUnit.Framework;

namespace WordFunneller.Core.Tests
{
    [TestFixture]
    public class GeneratingWordListShould
    {
        [Test]
        public void Split_line_up_into_normalized_list_of_words()
        {
            const string text = "The rustle of a woman’s dress was heard in the next room.";
            var expected = new[] { "The", "rustle", "of", "a", "woman’s", "dress", "was", "heard", "in", "the", "next", "room" };
            string[] actual;
            using (var stream = GetStream(text))
            {
                var generator = new StreamWordListGenerator(stream, new LineCleaner());
                actual = generator.Generate();
            }
            Assert.That(actual, Is.EqualTo(expected));
        }

        //Convert string to filestream in c#
        //https://stackoverflow.com/questions/17833080/convert-string-to-filestream-in-c-sharp#answer-17833177
        private static Stream GetStream(string text)
        {
            //Stream must not close until the generator is complete
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}