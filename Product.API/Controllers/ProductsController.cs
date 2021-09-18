using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Models;
using Product.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        //Constructor Injection
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Search Product By Id (GET/searchProductbyId(Input:ProductId|Output:Product object)
        [HttpGet("{id:int}")]
        public async Task<IActionResult> searchProductById([FromRoute] int id)
        {
            var product = await _productRepository.searchProductByIdAsync(id);
            return Ok(product);
        }
        //Search Product By Name (GET/searchProductbyName(Input:ProductName|Output:Product object))
        [HttpGet("GetProductByName/{name}")]
        public async Task<IActionResult> searchProductByName([FromRoute] string name)
        {
            var product = await _productRepository.searchProductByNameAsync(name);
            return Ok(product);
        }
        //POST/addProductRating(product ID,rating| Output:Sataus)
        [HttpPost("addRating")]
        public async Task<IActionResult> addProductRating(int ProductId, int rating)
        {
            var id = await _productRepository.addProductRatingAsync(ProductId,rating);
            if(id!=0 )
            {
                return Ok("Success");
            }
          
            return NotFound("Service not available");
        }
       



    }
}