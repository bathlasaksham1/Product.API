using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Data
{
    public class Products
    {
       
        public int Id { get; set; }
       
        public double Price { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
       
        public string Image_Name { get; set; }
       
        public int Rating { get; set; }
       
        public int No_Of_Units { get; set; }
    }
}
