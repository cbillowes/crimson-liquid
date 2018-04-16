using System.Collections.Generic;
using System.IO;

namespace WordFunneller.Core
{
    public class StreamWordListGenerator: IListGenerator
    {
        private readonly Stream _stream;
        private readonly ICleaner _cleaner;

        public StreamWordListGenerator(
            Stream stream,
            ICleaner cleaner)
        {
            _stream = stream;
            _cleaner = cleaner;
        }

        public string[] Generate()
        {
            var words = new List<string>();
            using (var bufferedStream = new BufferedStream(_stream))
            using (var streamReader = new StreamReader(bufferedStream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var cleaned = _cleaner.Clean(line);
                    words.AddRange(cleaned);
                }
            }
            return words.ToArray();
        }
    }
}