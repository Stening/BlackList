using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlackList.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        public DateTime TimeStamp{ get; set; }

        [ForeignKey("PreviousMessage")]
        public int PreviousMessageID { get; set; }
        public Message PreviousMessage { get; set; }

        [ForeignKey("Sender")]
        public int SenderUserID { get; set; }
        public ListUser Sender { get; set; }

        [ForeignKey("chatRoom")]
        public int ChatRoomID { get; set; }
        public ChatRoom chatRoom { get; set; }


    }
}