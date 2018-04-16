using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using WordFunneller.Core;
using static System.Console;

namespace WordFunneller.Console
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var summary = new List<Summary>();
            var input = new ConsoleKeyInfo();
            while (input.Key != ConsoleKey.N)
            {
                Greeting();

                var filepath = GetValidatedFilePath(args);
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                var words = ReadFile(filepath);
                DisplayFrequentWord(words);
                DisplayFrequentLetterWord(words);
                DisplayHighestScoredWord(words);
                Complete(summary, filepath, stopWatch.ElapsedMilliseconds);

                stopWatch.Stop();
                input = ReadKey();

                if (input.Key == ConsoleKey.N)
                {
                    DisplaySummary(summary);
                }
            }
        }

        private static void DisplaySummary(List<Summary> summary)
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Thank you for playing along!");
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("Here is this session's summary");
            WriteLine();
            ResetColor();

            foreach (var item in summary)
            {
                WriteLine($"  >>  {item.File}: {item.FileSize:0.00} MB took {item.MilliSeconds}ms to process.");
            }

            WriteLine();
            WriteLine("Press any key to quit.");
            ReadKey();
        }

        private static void Greeting()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Welcome to the Word Analysis game");
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("It's a game because somebody said so");
            WriteLine();
            ResetColor();
        }

        private static string[] ReadFile(string filepath)
        {
            WriteLine($"Reading from file. Please wait ....");
            WriteLine();

            using (var fileStream = new FileStream(filepath, FileMode.Open))
            {
                var cleaner = new LineCleaner();
                var list = new StreamWordListGenerator(fileStream, cleaner);
                var words = list.Generate();
                return words;
            }
        }

        private static void DisplayFrequentWord(string[] words)
        {
            var calculator = new FrequentWordCalculator();
            (string word, int total) = calculator.Calculate(words);

            Write("  >>  Most frequent word: ");
            WriteHighlightedWord(word);
            Write("ocurred");
            WriteHighlightedWord(total.ToString());
            WriteLine("times.");
            WriteLine();
        }

        private static void DisplayFrequentLetterWord(string[] words)
        {
            const int numberOfCharacters = 7;
            var calculator = new FrequentLengthCalculator(numberOfCharacters);
            (string word, int total) = calculator.Calculate(words);

            Write($"  >>  Most frequent {numberOfCharacters}-character word: ");
            if (total == 0)
            {
                WriteHighlightedWord("None found");
                WriteLine(".");
                WriteLine();
            }
            else
            {
                WriteHighlightedWord(word);
                Write("ocurred");
                WriteHighlightedWord(total.ToString());
                WriteLine("times.");
                WriteLine();
            }
        }

        private static void DisplayHighestScoredWord(string[] words)
        {
            var calculator = new ScrabbleHighestScoreCalculator();
            (string word, int total) = calculator.Calculate(words);

            Write("  >>  Highest scoring words: ");
            WriteHighlightedWord(word);
            Write("with a score of");
            WriteHighlightedWord(total.ToString());
            WriteLine(".");
            WriteLine();
        }

        private static void Complete(List<Summary> summaryList, string filepath, float elsapsedMilliseconds)
        {
            //How do you get the file size in C#?
            //https://stackoverflow.com/questions/1380839/how-do-you-get-the-file-size-in-c
            var fileSize = (float)new FileInfo(filepath).Length / 1024 / 1024;

            Write("  >>  Execution took");
            WriteHighlightedWord(elsapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
            Write("ms with a");

            //Formatting a float to 2 decimal places
            //https://stackoverflow.com/questions/6356351/formatting-a-float-to-2-decimal-places
            WriteHighlightedWord(fileSize.ToString("0.00"));

            WriteLine("MB file.");
            WriteLine();
            WriteLine("Press [N] to stop and any key to play again.");

            summaryList.Add(new Summary(filepath, fileSize, elsapsedMilliseconds));
        }

        private static void ValidateFilePath(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException("Cannot read from a missing file.", filepath);
            }
        }

        private static string GetValidatedFilePath(string[] args)
        {
            if (args.Length > 0)
            {
                return args[0];
            }
            Write("File location: ");
            ForegroundColor = ConsoleColor.Green;
            var path = ReadLine();
            ValidateFilePath(path);
            ResetColor();
            return path;
        }

        private static void WriteHighlightedWord(string word)
        {
            Write(" ");
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Yellow;
            Write($"  {word}  ");
            ResetColor();
            Write(" ");
        }
    }
}
