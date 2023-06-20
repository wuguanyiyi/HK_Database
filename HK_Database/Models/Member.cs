using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK_Database.Models
{
    public class Member
    {
        [Key]
        [Required] //not null
        public string MemberId { get; set; }

        [Required]
        public string MemberName { get; set; }

        [Required]
        public string MemberEmail { get; set; }

        [Required]
        public string MemberPhone { get; set; }

        [Required]
        public string APIKey { get; set; }

        [Required]
        public string MemberAccount { get; set; }

        [Required]
        public string MemberPassword { get; set; }

        
        public ICollection<Applications> Applications { get; set; }
    }
}
