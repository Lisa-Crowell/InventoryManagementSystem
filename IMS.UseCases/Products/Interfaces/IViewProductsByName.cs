using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interfaces;

public interface IViewProductsByName
{
    Task<IEnumerable<Product>> ExecuteAsync(string name = "");
}