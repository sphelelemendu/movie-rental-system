using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieApplication.Models;

namespace MovieApplication.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer customer { get; set; }
    }
}