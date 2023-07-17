
using Data;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ImageController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly ServiceContext _serviceContext;

        public ImageController(IProductService productService, ServiceContext serviceContext)
        {
            _productService = productService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertProduct")]
        public int Post([FromBody] ProductItem imageItem)
        {
           
                return _productService.insertProduct(imageItem);
        }

       
        
    }
}

