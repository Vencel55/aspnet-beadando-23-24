using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nagyBead.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RateId { get; set; }
        [ForeignKey("AspNetUsers")]
        [Required]
        public long UserId { get; set; }
        [ForeignKey("Research")]
        [Required]
        public long ResearchId { get; set; }
        [Required]
        public int Understandability { get; set; }
        [Required]
        public int Quality { get; set; }
        public string RateText { get; set; }
    }
}
