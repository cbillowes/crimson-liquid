using System;
using System.Diagnostics;
using System.IO;
using WordAnalysis.Core;
using static System.Console;

namespace WordAnalysis.Console
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var key = ConsoleKey.Y;
            while (key != ConsoleKey.N)
            {
                Clear();
                Write("Open file from: ");
                var path = ReadLine() ?? @"C:\workspace\resources\2600-0.txt";
                WriteLine($"Reading from {path}");
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException("Cannot read from a missing file.", path);
                }

                var sw = new Stopwatch();
                sw.Start();
                long filesize = 0;
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var cleaner = new LineCleaner();
                    var list = new StreamWordListGenerator(fileStream, cleaner);
                    var words = list.Generate();
                    DisplayFrequent(words);
                    DisplayLength(words);
                    DisplayScore(words);
                }
                sw.Stop();

                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                Write("  >>  Execution took");
                CustomWrite(sw.Elapsed.Seconds.ToString());
                ForegroundColor = ConsoleColor.Red;
                //How do you get the file size in C#?
                //https://stackoverflow.com/questions/1380839/how-do-you-get-the-file-size-in-c
                Write("seconds to run on " + (new FileInfo(path).Length / 1024) + "MB !");
                WriteLine();
                WriteLine();
                ResetColor();

                Write("We will continue until you [N]o longer want to play...");

                key = ReadKey().Key;
            }
        }

        static void CustomWrite(string word)
        {
            Write(" ");
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Yellow;
            Write($"  {word}  ");
            ResetColor();
            Write(" ");
        }

        static void DisplayFrequent(string[] words)
        {
            WriteLine();
            var calculator = new FrequentWordCalculator();
            var result = calculator.Calculate(words);
            Write("  >>  Most frequent word: ");
            CustomWrite(result.word);
            Write("ocurred");
            CustomWrite(result.total.ToString());
            Write("times.");
            WriteLine();
        }

        static void DisplayLength(string[] words)
        {
            WriteLine();
            var calculator = new FrequentLengthCalculator(limit: 7);
            var result = calculator.Calculate(words);
            Write("  >>  Most frequent 7-character word: ");
            CustomWrite(result.word);
            Write("ocurred");
            CustomWrite(result.total.ToString());
            Write("times.");
            WriteLine();
        }

        static void DisplayScore(string[] words)
        {
            WriteLine();
            var calculator = new ScrabbleHighestScoreCalculator();
            var result = calculator.Calculate(words);
            Write("  >>  Highest scoring words: ");
            CustomWrite(result.word);
            Write("with a score of");
            CustomWrite(result.total.ToString());
            Write(".");
            WriteLine();
        }
    }
}
