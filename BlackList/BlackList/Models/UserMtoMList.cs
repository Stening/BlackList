using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlackList.Models
{
    public class UserMtoMList
    {
        [Required]
        public int Authority { get; set; }

        [Required, Column(Order =0) Key, ForeignKey("user")]
        public string UserID { get; set; }
        [Required]
        public virtual ApplicationUser user { get; set; }
        

        [Required, Column(Order = 1)Key, ForeignKey("List")]
        public int ListID { get; set; }
        [Required]
        public virtual CheckList List { get; set; }
    }
}