﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}