using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Models
{
    public class ProductModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image_Name { get; set; }
        [Required]
        public int  Rating { get; set; }
        [Required]
        public int No_Of_Units { get; set; }
       
        public string Category { get; set; }
    }
}
