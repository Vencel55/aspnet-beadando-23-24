using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nagyBead.Models
{
    public class Research
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ResearchId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int MinFillNumber { get; set; }
        [ForeignKey("AspNetUsers")]
        public long AdminID { get; set; }
    }
}
