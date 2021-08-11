
using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApplication.Dtos
{
    public class NewRentalDto
    {
        public int customerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}