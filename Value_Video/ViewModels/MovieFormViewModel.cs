﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Value_Video.Models;

namespace Value_Video.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }


    }
}