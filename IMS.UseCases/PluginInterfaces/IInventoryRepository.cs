using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetInventoryByNameAsync(string name);
    Task<bool> ExistsAsync(Inventory inventory);
    Task AddInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(Inventory inventory);
    Task<Inventory> GetInventoryByIdAsync(int inventoryId);
}