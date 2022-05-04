using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [RegularExpression(@"\w+")]
        [Required]
        public string Text { get; set; } = null!;

        /// <summary>
        /// Sentiment score.
        /// </summary>
        [Range(-1d,1d)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Score { get; set; }
    }
}
