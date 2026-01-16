using MVC_Core_Prj.Models;

namespace MVC_Core_Prj.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product ? GetProductById(int id); 
    }
}
