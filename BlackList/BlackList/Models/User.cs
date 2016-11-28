using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackList.Models
{
    public class User
    {
        [Required Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string Mail { get; set; }
        public bool IsMailVerified { get; set; }
        public DateTime DateCreated { get; set; }

    }
}