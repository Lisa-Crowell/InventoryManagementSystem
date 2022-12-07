using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
}