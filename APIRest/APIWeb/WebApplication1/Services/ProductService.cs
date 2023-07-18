using Data;
using Entities.Entities;
using WebApplication1.IServices;


namespace WebApplication1.Services
{
    public class ProductService : BaseContextService, IProductService
    {
        public ProductService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int insertProduct(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
            return productItem.Id;
        }

        //public int insertProduct(ProductItem productItem)
        //{
        //    _serviceContext.Products.Add(productItem);
        //    _serviceContext.SaveChanges();
        //    return productItem.Id;
        //}
    }
}
