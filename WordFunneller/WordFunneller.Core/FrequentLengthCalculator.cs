using System.Collections.Generic;
using System.Linq;

namespace WordFunneller.Core
{
    public class FrequentLengthCalculator : ICalculator
    {
        private readonly int _limit;

        public FrequentLengthCalculator(int limit)
        {
            _limit = limit;
        }

        public (string word, int total) Calculate(IEnumerable<string> words)
        {
            var listOfWords = words.ToList();
            if (!listOfWords.Any()) return (string.Empty, 0);

            var frequent = listOfWords
                .GroupBy(w => w.ToLower())
                .Where(w => w.Key.Length == _limit)
                .Select(w => new
                {
                    Word = w.Key, 
                    Occurrance = w.Count(), 
                    w.Key.Length,
                })
                .OrderByDescending(w => w.Occurrance)
                .ThenByDescending(w => w.Occurrance)
                .ThenBy(w => w.Word)
                .FirstOrDefault();
            
            return (frequent?.Word, frequent?.Occurrance ?? 0);
        }
    }
}