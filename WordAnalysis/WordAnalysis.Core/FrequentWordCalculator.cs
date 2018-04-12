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
            var listOfWords = words.ToList();
            if (!listOfWords.Any()) return (string.Empty, 0);

            var grouped = listOfWords.GroupBy(w => w.ToLower());
            var selected = grouped.Select(w => new
            {
                Word = w.Key, 
                Occurrance = w.Count(), 
            });
            var ordered = selected.OrderByDescending(w => w.Occurrance).ThenBy(w => w.Word);
            var frequent = ordered.First();
            return (frequent.Word, frequent.Occurrance);
        }
    }
}
