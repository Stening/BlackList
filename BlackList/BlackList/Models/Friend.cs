using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlackList.Models
{
    public class Friend
    {

        [Required, Key, Column(Order = 0), ForeignKey("user")]
        public string UserID { get; set; }
        public virtual ApplicationUser user { get; set; }

        [Required, Key, Column(Order = 1), ForeignKey("friend")]
        public string FriendID { get; set; }
        public virtual ApplicationUser friend { get; set; }

    }
}