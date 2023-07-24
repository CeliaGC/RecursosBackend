
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
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly ServiceContext _serviceContext;

        public ProductController(IProductService productService, ServiceContext serviceContext)
        {
            _productService = productService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertProduct")]
        public int Post([FromQuery] string userName, [FromQuery] string userPassword, [FromBody] ProductItem productItem)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.Name == userName
                                   && u.Password == userPassword
                                   && u.UserRol == 1)
                                .FirstOrDefault();

            if (selectedUser != null)
            {
                return _productService.insertProduct(productItem);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe"); 
            }

            
        }

       
        
    }
}

