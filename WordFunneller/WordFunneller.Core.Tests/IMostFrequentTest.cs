namespace WordFunneller.Core.Tests
{
    public interface IMostFrequentTest
    {
        void Return_default_data_when_no_items_exist();

        void Return_first_when_no_duplicates();

        void Return_highest_with_duplicates();

        void Return_highest_ordered_with_duplicates();

        void Return_case_insensitive_order();
    }
}