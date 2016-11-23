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
        public int UserID { get; set; }
        public virtual User user { get; set; }

        [Required, Key, Column(Order = 1), ForeignKey("friend")]
        public int FriendID { get; set; }
        public virtual User friend { get; set; }

    }
}