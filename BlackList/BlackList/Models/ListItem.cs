using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlackList.Models
{
    public class ListItem
    {
        [Key]
        public int ListItemID { get; set; }
        [Required]
        public string ItemName { get; set; }

        [ForeignKey("List")]
        public int ListID { get; set; }
        public virtual CheckList List { get; set; }

    }
}