using System.Collections.Generic;
using System.Linq;

namespace WordAnalysis.Core
{
    public class ScrabbleHighestScoreCalculator: ICalculator
    {
        public (string word, int total) Calculate(IEnumerable<string> words)
        {
            var listOfWords = words.ToList();
            if (!listOfWords.Any()) return (string.Empty, 0);

            var grouped = listOfWords.GroupBy(w => w.ToLower());
            var selected = grouped.Select(w => new
            {
                Word = w.Key, 
                Score = ScrabbleLetterMapper.Map(w.Key)
            });
            var ordered = selected
                .OrderByDescending(w => w.Score)
                .ThenBy(w => w.Word);
            var highest = ordered.First();
            return (highest.Word, highest.Score);
        }
    }
}
