using System.Collections.Generic;

namespace WordAnalysis.Core
{
    public interface ICalculator
    {
        (string word, int total) Calculate(IEnumerable<string> words);
    }
}
