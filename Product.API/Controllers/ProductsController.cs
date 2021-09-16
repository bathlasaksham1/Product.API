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
        //Retrieve all Products From IProductRepository
        [HttpGet("")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products =await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        //Search Product By Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }
        //Search Product By Name
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductByName([FromRoute] string name)
        {
            var product = await _productRepository.GetProductByNameAsync(name);
            return Ok(product);
        }

    }
}