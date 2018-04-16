using System;
using System.Text.RegularExpressions;

namespace WordFunneller.Core
{
    public class LineCleaner: ICleaner
    {
        public string[] Clean(string text)
        {
            var regex = new Regex(@"(\w*@\w*.\w*)*(http:\/\/w*\.w*.\w*.\w*)*[^a-zA-ZÀ-ÿ-’']");
            var words = regex.Replace(text, " ");
            var cleaned = words.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return cleaned;
        }
    }
}
