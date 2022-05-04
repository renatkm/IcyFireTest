namespace IcyFireTest.Models
{
    public class FilteredWordModel
    {
        public IEnumerable<Word> Words { get; set; } = null!;

        public int FilteredValue { get; set; }
    }
}
