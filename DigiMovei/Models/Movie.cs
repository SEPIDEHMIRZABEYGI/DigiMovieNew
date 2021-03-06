﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigiMovei.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsExsists { get; set; }
        public  virtual  Category Category { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateReleasd { get; set; }

        public byte NumberInStock { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}