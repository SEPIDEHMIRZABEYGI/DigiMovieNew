﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiMovei.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsExsists { get; set; }
        public  virtual  Category Category { get; set; }
    }
}