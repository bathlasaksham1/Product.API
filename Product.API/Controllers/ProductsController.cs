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
    //[BindProperties(SupportsGet =true)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        //Constructor Injection
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        //Retrieve all Products From IProductRepository
        //Retrieve all Products From IProductRepository
        [HttpGet("")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
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
        [HttpGet("GetProductByName/{name}")]
        public async Task<IActionResult> GetProductByName([FromRoute] string name)
        {
            var product = await _productRepository.GetProductByNameAsync(name);
            return Ok(product);
        }
        //ADD any new Product in Database (Post method)
        [HttpPost("")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductModel productModel)
        {
            var id = await _productRepository.AddProductAsync(productModel);
            //We are adding a new prroduct , so we need 201 request and we use CreatedAtAction method
            return CreatedAtAction(nameof(GetProductById), new { id = id, controller = "Products" }, productModel);
        }
        //search by Category
        [HttpGet("{CategoryName}")]
        public async Task<IActionResult> GetAllCategory([FromRoute] string CategoryName )
        {
            var products = await _productRepository.GetAllCategoriesAsync(CategoryName);
            return Ok(products);
        }



    }
}