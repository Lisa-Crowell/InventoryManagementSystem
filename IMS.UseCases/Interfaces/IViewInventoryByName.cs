using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IViewInventoryByName
{
    Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
}