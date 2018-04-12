using System;
using System.Collections.Generic;
using System.Linq;

namespace WordAnalysis.Core
{
    public class FrequentWordCalculator : ICalculator
    {
        //How to easily initialize a list of Tuples?
        //https://stackoverflow.com/questions/8002455/how-to-easily-initialize-a-list-of-tuples
        //Multiple Order By with LINQ
        //https://stackoverflow.com/questions/2318885/multiple-order-by-with-linq
        public (string word, int total) Calculate(IEnumerable<string> words)
        {
            var ranked =  words
                .GroupBy(w => w.ToLower())
                .Select(w => new Tuple<string, int>(w.Key, w.Count()))
                .OrderByDescending(w => w.Item2)
                .ThenBy(w => w.Item1.ToLower())
                .FirstOrDefault() ?? new Tuple<string, int>(string.Empty, 0);
            return (ranked.Item1, ranked.Item2);
        }
    }
}
