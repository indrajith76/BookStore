﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Choose email")]
        [EmailAddress]
        public string MyField { get; set; }
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage ="Please enter the title of your book ")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage ="Please enter the total pages")]
        [Display(Name ="Total pages of book")]
        public int? TotalPages { get; set; }
    }
}
