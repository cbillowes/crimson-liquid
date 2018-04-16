using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFunneller.Core
{
    public class FrequentWordCalculator : ICalculator
    {
        public (string word, int total) Calculate(IEnumerable<string> words)
        {
            var listOfWords = words.ToList();
            if (!listOfWords.Any()) return (string.Empty, 0);

            var frequent = listOfWords
                .GroupBy(w => w.ToLower())
                .Select(w => new
                {
                    Word = w.Key,
                    Occurrance = w.Count(),
                })
                .OrderByDescending(w => w.Occurrance)
                .ThenBy(w => w.Word)
                .First();

            return (frequent.Word, frequent.Occurrance);
        }

        public string[] Clean(string text)
        {
            var regex = new Regex(@"[^a-zA-ZÀ-ÿ-’' ](http:\/\/\w*\.\w*.\w*)*(\w*@\w*.\w*)*");
            var split = text
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => !regex.IsMatch(w));
            return split.ToArray();
        }
    }
}