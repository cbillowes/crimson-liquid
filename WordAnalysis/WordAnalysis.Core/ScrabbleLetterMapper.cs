using System.Collections.Generic;
using System.Linq;

namespace WordAnalysis.Core
{
    internal class ScrabbleLetterMapper
    {
        internal static int Map(string word)
        {
            var letters = word.ToLower().ToCharArray();
            var selected = letters.Select(GetScore);
            var score = selected.Sum();
            return score;
        }

        private static int GetScore(char letter)
        {
            var scoring = GetScoring();
            var filtered = scoring.Where(l => l.Range.Contains(letter));
            var selected = filtered.Select(l => l.Score);
            var score = selected.FirstOrDefault();
            return score;
        }

        private static IEnumerable<ScrabbleLetters> GetScoring()
        {
            var scoring = new List<ScrabbleLetters>
            {
                new ScrabbleLetters
                {
                    Range = new[] { 'a', 'e', 'i', 'l', 'n', 'o', 'r', 's', 't', 'u' },
                    Score = 1
                },
                new ScrabbleLetters
                {
                    Range = new[] { 'd', 'g' },
                    Score = 2
                },
                new ScrabbleLetters
                {
                    Range = new[] { 'b', 'c', 'm', 'p' },
                    Score = 3
                },
                new ScrabbleLetters
                {
                    Range = new[] { 'f', 'h', 'v', 'w', 'y' },
                    Score = 4
                },
                new ScrabbleLetters
                {
                    Range = new[] { 'k' },
                    Score = 5
                },
                new ScrabbleLetters
                {
                    Range = new[] { 'j', 'x' },
                    Score = 8
                },
                new ScrabbleLetters
                {
                    Range = new[] { 'q', 'z' },
                    Score = 10
                },
            };
            return scoring;
        }
    }

    internal struct ScrabbleLetters
    {
        internal char[] Range { get; set; }
        internal int Score { get; set; }
    }
}
