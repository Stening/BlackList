using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShoppingList.Models
{
    public class ShoppingList
    {
        [Key, Required]
        public int ShoppingListID { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }



    }
}