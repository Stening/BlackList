using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlackList.Models
{
    public class ChatRoomUser
    {
        [ForeignKey("chatRoom"), Key, Column(Order = 0)]
        public int ChatRoomID { get; set; }
        public ChatRoom chatRoom { get; set; }


        [ForeignKey("user"), Key, Column(Order = 1)]
        public string UserID { get; set; }
        public ApplicationUser user{ get; set; }

    }
}