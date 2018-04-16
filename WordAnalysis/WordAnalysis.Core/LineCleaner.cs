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
            var regex = new Regex(@"(\w*@\w*.\w*)*(http:\/\/w*\.w*.\w*.\w*)*[^a-zA-ZÀ-ÿ-’']");
            var words = regex.Replace(text, " ");
            var cleaned = words.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return cleaned;
        }
    }
}
