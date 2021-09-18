using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
           
        }
            //GET/searchProductbyId(Input:ProductId|Output:Product object)
        public async Task<ProductModel> searchProductByIdAsync(int ProductId)
        {
            var records = await _context.Products.Where(x => x.Id == ProductId).Select(x => new ProductModel
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name,
                Description = x.Description,
                Image_Name = x.Image_Name,
                Rating = x.Rating,
                No_Of_Units = x.No_Of_Units,
                Category = x.Category

            }).FirstOrDefaultAsync();
            return records;

        }
        // GET/searchProductbyName(Input:ProductName|Output:Product object)
        public async Task<ProductModel> searchProductByNameAsync(string ProductName)
        {
            var records = await _context.Products.Where(x => x.Name == ProductName).Select(x => new ProductModel
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name,
                Description = x.Description,
                Image_Name = x.Image_Name,
                Rating = x.Rating,
                No_Of_Units = x.No_Of_Units,
                Category = x.Category

            }).FirstOrDefaultAsync();
            return records;

        }
        //POST/addProductRating(product ID,rating| Output:Sataus)
        public async Task<int> addProductRatingAsync(int ProductId, int Rating)
        {
            var data = _context.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            
            data.Rating = Rating;

             _context.Products.Update(data);

            await _context.SaveChangesAsync();
            return data.Id;
        }
       

    }
}


