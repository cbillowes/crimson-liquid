using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace WordAnalysis.Core
{
    public class ScrabbleHighestScoreCalculator : ICalculator
    {
        public (string word, int total) Calculate(IEnumerable<string> words)
        {
            var listOfWords = words.ToList();
            if (!listOfWords.Any()) return (string.Empty, 0);

            var scoredWords =
                from word in listOfWords
                where !word.Contains("-")
                group word by word.ToLower() into lowered
                orderby lowered.Key
                select new
                {
                    Word = lowered.Key,
                    Score = ScrabbleLetterMapper.Map(lowered.Key)
                };
            
            var highest = scoredWords
                .OrderByDescending(w => w.Score)
                .First();

            return (highest.Word, highest.Score);
        }
    }
}
