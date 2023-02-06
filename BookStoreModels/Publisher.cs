﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public string PublisherName { get; set; }
    }
}
