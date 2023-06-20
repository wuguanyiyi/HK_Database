using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK_Database.Models
{
    public class Datas
    {
        [Key]
        [Required]
        public string DataId { get; set; }

        [Required]
        public string DataType { get; set; }

        [Required]
        public string DataPath { get; set; }

        [Required]
        public string ApplicationId { get; set; }
        
        [ForeignKey("ApplicationId")]
        public Applications Applications { get; set; }

        
        public ICollection<Embedding> Embedding { get; set; }
    }
}
