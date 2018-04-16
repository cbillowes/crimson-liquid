using System.Collections.Generic;

namespace WordFunneller.Core
{
    public interface ICalculator
    {
        (string word, int total) Calculate(IEnumerable<string> words);
    }
}
