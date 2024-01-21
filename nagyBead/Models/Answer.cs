using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nagyBead.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AnswerId { get; set; }
        [ForeignKey("AspNetUsers")]
        public long UserId { get; set; }
        [ForeignKey("Question")]
        [Required]
        public long QuestionId { get; set; }
        [Required]
        public string AnswerText { get; set; }
    }
}
