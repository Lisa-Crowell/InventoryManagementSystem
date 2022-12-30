using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Products;

public class AddProduct : IAddProduct
{
    private readonly IProductRepository _productRepository;
    
    public AddProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task ExecuteAsync(Product product)
    {
        if (product == null) return;
        
        await _productRepository.AddProductAsync(product);
    }
}