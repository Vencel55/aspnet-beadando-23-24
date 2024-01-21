using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nagyBead.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long QuestionId { get; set; }
        [ForeignKey("Research")]
        [Required]
        public long ResearchId { get; set; }
        [Required]
        public string QuestionText { get; set; }
    }
}
