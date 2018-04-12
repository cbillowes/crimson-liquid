using System;
using System.Text.RegularExpressions;

namespace WordAnalysis.Core
{
    public class LineCleaner: ICleaner
    {
        //http://regexstorm.net/tester
        public string[] Clean(string text)
        {
            var trimmed = text.Trim();
            var regex = new Regex(@"(\\r\\n)*([^a-zA-ZÀ-ÿ-’' ])*");
            var cleaned = regex.Replace(trimmed, string.Empty);
            var split = cleaned.Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return split;
        }
    }
}
