﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK_Database.Models
{
    public class Users
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Required]
        public string UserAccount { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserPhone { get; set; }

        [Required]
        public string ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Applications Applications { get; set; }


        public ICollection<Chats> Chats { get; set; }
    }
}
