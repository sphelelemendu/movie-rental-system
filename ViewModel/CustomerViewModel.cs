using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApplication.ViewModel
{
    public class CustomerViewModel
    {
        public Movie movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}