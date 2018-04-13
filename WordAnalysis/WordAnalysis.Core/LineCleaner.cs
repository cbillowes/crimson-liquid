using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordAnalysis.Core
{
    public class LineCleaner: ICleaner
    {
        //http://regexstorm.net/tester
        //https://regex101.com/
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
