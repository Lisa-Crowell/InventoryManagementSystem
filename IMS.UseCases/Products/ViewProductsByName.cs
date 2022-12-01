using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Products;

public class ViewProductsByName : IViewProductsByName
{
    private readonly IProductRepository _productRepository;
    
    public ViewProductsByName(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<Product>> ExecuteAsync(string name)
    {
        return await _productRepository.GetProductsByNameAsync(name);
    }
}