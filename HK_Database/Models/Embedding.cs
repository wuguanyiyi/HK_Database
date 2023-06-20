using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK_Database.Models
{
    public class Embedding
    {
        [Key]
        [Required]
        public string Index { get; set; }

        [Required]
        public string EmbeddingQuestion { get; set; }

        [Required]
        public string EmbeddingAnswer { get; set;}

        [Required]
        public string QA { get; set;}

        [Required]
        public string EmbeddingVectors { get; set;}
        [Required]
        public string DataId { get; set;}

        [ForeignKey("DataId")]
        public Datas Datas { get; set; }

    }
}
