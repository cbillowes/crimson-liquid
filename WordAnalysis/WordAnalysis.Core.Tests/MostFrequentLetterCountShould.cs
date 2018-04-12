using System;
using NUnit.Framework;

namespace WordAnalysis.Core.Tests
{
    [TestFixture]
    public class MostFrequentLetterCountShould: IMostFrequentTest
    {
        private ICalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new FrequentLengthCalculator();
        }

        public void Return_default_data_when_no_items_exist()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Return_first_when_no_duplicates()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Return_highest_with_duplicates()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Return_highest_ordered_with_duplicates()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Return_case_insensitive_order()
        {
            throw new NotImplementedException();
        }
    }
}
