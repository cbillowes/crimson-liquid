namespace WordAnalysis.Core.Tests
{
    public interface IMostFrequentTest
    {
        void Be_the_first_word_with_highest_occurrance();

        void Be_the_first_word_in_with_highest_occurrance_and_multiple_words_of_the_same_occurance();

        void Be_ordered_by_word_ascending();

        void Be_ordered_regardless_of_case();
    }
}
