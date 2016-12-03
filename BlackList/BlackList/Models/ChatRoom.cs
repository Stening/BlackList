using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlackList.Models
{
    public class ChatRoom
    {
        [Key]
        public int ChatRoomID { get; set; }



        [ForeignKey("shoppingList")]
        public int ShoppingListID { get; set; }
        public List shoppingList { get; set; }


    }
}