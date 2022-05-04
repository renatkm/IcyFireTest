namespace IcyFireTest.Models
{
    public class Word
    {
        /// <summary>
        /// Identificator of the word.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The content.
        /// </summary>
        public string Text { get; set; } = null!;

        /// <summary>
        /// Sentiment score.
        /// </summary>
        public decimal Score { get; set; }
    }
}
