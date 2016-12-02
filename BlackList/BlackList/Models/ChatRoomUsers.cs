using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlackList.Models
{
    public class ChatRoomUsers
    {

        public int ChatRoomID { get; set; }

        [ForeignKey("user"), Key, Column(Order = 0)]
        public int UserID { get; set; }
        public User user{ get; set; }

    }
}