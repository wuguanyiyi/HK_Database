using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK_Database.Models
{
    public class QAHistory
    {
        [Key]
        [Required]
        public string QAHistoryId { get; set; }

        [Required]
        public string QAHistoryQ { get; set; }

        [Required]
        public string QAHistoryA { get; set; }

        [Required]
        public string QAHistoryVectors { get; set; }
        [Required]
        public string ChatId { get; set; }

        [ForeignKey("ChatId")]
        public Chats Chats { get; set; }
    }
}
