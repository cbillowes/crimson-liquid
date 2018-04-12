using System;
using NUnit.Framework;

namespace WordAnalysis.Core.Tests
{
    public class ScoredWordShould
    {
        private ICalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ScrabbleHighestScoreCalculator();
        }

        [Test]
        public void Calculate_score_for_word()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Return_word_with_highest_score()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Order_list_ascending()
        {
            throw new NotImplementedException();
        }
    }
}
