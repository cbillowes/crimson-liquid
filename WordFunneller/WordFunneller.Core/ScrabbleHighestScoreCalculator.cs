using System.Collections.Generic;
using System.Linq;

namespace WordFunneller.Core
{
    public class ScrabbleHighestScoreCalculator : ICalculator
    {
        public (string word, int total) Calculate(IEnumerable<string> words)
        {
            var listOfWords = words.ToList();
            if (!listOfWords.Any()) return (string.Empty, 0);

            var highest = listOfWords
                .Distinct()
                .Where(w => !w.Contains("-"))
                .GroupBy(w => w.ToLower())
                .Select(w => new
                {
                    Word = w.Key,
                    Score = ScrabbleLetterMapper.Map(w.Key),
                })
                .OrderByDescending(w => w.Score)
                .ThenBy(w => w.Word)
                .First();

            return (highest.Word, highest.Score);
        }
    }
}