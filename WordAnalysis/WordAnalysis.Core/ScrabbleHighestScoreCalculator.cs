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

            var selected = listOfWords.Select(w => new
            {
                Word = w, 
                Score = ScrabbleLetterMapper.Map(w)
            });
            var ordered = selected.OrderBy(w => w.Word);
            var highest = ordered.First();
            return (highest.Word, highest.Score);
        }
    }
}
