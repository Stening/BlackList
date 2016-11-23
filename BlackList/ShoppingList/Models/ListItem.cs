using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShoppingList.Models
{
    public class ListItem
    {
        [Key]
        public int ListItemID { get; set; }
        [Required]
        public string ItemName { get; set; }

        [ForeignKey("shoppingList")]
        public int ListID { get; set; }
        public virtual ShoppingList shoppingList { get; set; }

    }
}