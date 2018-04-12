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
            switch (letter)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'l':
                case 'n':
                case 'o':
                case 'r':
                case 's':
                case 't':
                case 'u':
                    return 1;
                case 'd':
                case 'g':
                    return 2;
                case 'b':
                case 'c':
                case 'm':
                case 'p':
                    return 3;
                case 'f':
                case 'h':
                case 'v':
                case 'w':
                case 'y':
                    return 4;
                case 'k':
                    return 5;
                case 'j':
                case 'x':
                    return 8;
                case 'q':
                case 'z':
                    return 10;
                default:
                    return 0;
            }
        }

        //private static int GetScore(char letter)
        //{
        //    var scoring = GetScoring();
        //    var filtered = scoring.Where(l => l.Range.Contains(letter));
        //    var selected = filtered.Select(l => l.Score);
        //    var score = selected.FirstOrDefault();
        //    return score;
        //}

        //private static IEnumerable<ScrabbleLetters> GetScoring()
        //{
        //    var scoring = new List<ScrabbleLetters>
        //    {
        //        new ScrabbleLetters
        //        {
        //            Range = new[] { 'a', 'e', 'i', 'l', 'n', 'o', 'r', 's', 't', 'u' },
        //            Score = 1
        //        },
        //        new ScrabbleLetters
        //        {
        //            Range = new[] { 'd', 'g' },
        //            Score = 2
        //        },
        //        new ScrabbleLetters
        //        {
        //            Range = new[] { 'b', 'c', 'm', 'p' },
        //            Score = 3
        //        },
        //        new ScrabbleLetters
        //        {
        //            Range = new[] { 'f', 'h', 'v', 'w', 'y' },
        //            Score = 4
        //        },
        //        new ScrabbleLetters
        //        {
        //            Range = new[] { 'k' },
        //            Score = 5
        //        },
        //        new ScrabbleLetters
        //        {
        //            Range = new[] { 'j', 'x' },
        //            Score = 8
        //        },
        //        new ScrabbleLetters
        //        {
        //            Range = new[] { 'q', 'z' },
        //            Score = 10
        //        },
        //    };
        //    return scoring;
        //}
    }

    //internal struct ScrabbleLetters
    //{
    //    internal char[] Range { get; set; }
    //    internal int Score { get; set; }
    //}
}
