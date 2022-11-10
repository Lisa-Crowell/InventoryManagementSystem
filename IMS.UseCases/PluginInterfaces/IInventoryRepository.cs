using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetInventoryByNameAsync(string name);
    Task AddInventoryAsync(Inventory inventory);
}