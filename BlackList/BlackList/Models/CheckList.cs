using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlackList.Models
{
    public class CheckList
    {
        [Key, Required]
        public int ListID { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }



    }
}