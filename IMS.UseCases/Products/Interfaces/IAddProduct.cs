using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interfaces;

public interface IAddProduct
{
    Task ExecuteAsync(Product product);
}