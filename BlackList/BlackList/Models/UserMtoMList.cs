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
        public int UserID { get; set; }
        [Required]
        public virtual User user { get; set; }


        [Required, Column(Order = 1)Key, ForeignKey("shoppingList")]
        public int ShoppingListID { get; set; }
        [Required]
        public virtual ShoppingList shoppingList { get; set; }
    }
}