using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class ProductRepository : IProductRepository
{
    private List<Product> _products;
    
    public ProductRepository()
    {
        _products = new List<Product>()
        {
            new Product() {ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 150}
        };
    }
    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_products);
        
        return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddProductAsync(Product product)
    {
        if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) 
            return Task.CompletedTask;

        var maxId = _products.Max(x => x.ProductId);
        product.ProductId = maxId + 1;

        _products.Add(product);

        return Task.CompletedTask;
    }
}