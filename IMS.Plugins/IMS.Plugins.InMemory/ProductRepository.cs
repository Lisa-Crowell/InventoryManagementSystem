using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.Plugins.InMemory;

public class ProductRepository : IProductRepository
{
    private List<Product> _products;
    
    public ProductRepository()
    {
        _products = new List<Product>()
        {
            new Product() { }
        };
    }
    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_products);
        
        return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}