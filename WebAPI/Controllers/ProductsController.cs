using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]  // attribute
    public class ProductsController : ControllerBase
    {  
        
        // naming convention
        //c# & java 
        //IoC Container --> inversion of control
        IProductService _productService;
        // loosely coupling
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //dependency chain -->
            var result = _productService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
                return BadRequest(result.Message);
            
            
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }





    }
}
