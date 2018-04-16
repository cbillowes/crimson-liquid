using System.Linq;

namespace WordFunneller.Core
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
    }
}