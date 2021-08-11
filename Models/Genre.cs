using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieApplication.Models
{
    public class Genre
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}