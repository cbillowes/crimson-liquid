using System.Collections.Generic;
using System.Linq;

namespace WordAnalysis.Core
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
            
            var grouped = listOfWords.GroupBy(w => w.ToLower());
            var filtered = grouped.Where(w => w.Key.Length == _limit);
            var selected = filtered.Select(w => new
            {
                Word = w.Key, 
                Occurrance = w.Count(), 
                w.Key.Length,
            });
            var ordered = selected
                .OrderByDescending(w => w.Length)
                .ThenByDescending(w => w.Occurrance)
                .ThenBy(w => w.Word);
            var frequent = ordered.First();
            return (frequent.Word, frequent.Occurrance);
        }
    }
}
