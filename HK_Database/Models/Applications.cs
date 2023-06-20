using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK_Database.Models
{
    public class Applications
    {
        [Key]
        [Required]
        public string ApplicationId { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]
        public string MemberId { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        
        public ICollection<Datas>Datas { get; set; }

        
        public ICollection<Users> Users { get; set; }
        
    }
}
