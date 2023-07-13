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

        [HttpGet]
        public List<Product> Get()
        {
            //dependency chain -->

            var result = _productService.GetAll();
            return result.Data;

        }




    }
}
