﻿using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApplication.ViewModel
{
    public class RndomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}