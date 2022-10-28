using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private readonly List<Inventory> _inventories;
    
    public InventoryRepository()
    {
        _inventories = new List<Inventory>()
        {
            new Inventory{InventoryId = 1, InventoryName = "bike seat", Quantity = 10, Price = 10},
            new Inventory{InventoryId = 2, InventoryName = "bike tire", Quantity = 20, Price = 15},
            new Inventory{InventoryId = 3, InventoryName = "bike pedal", Quantity = 20, Price = 5},
            new Inventory{InventoryId = 4, InventoryName = "bike body", Quantity = 10, Price = 20},
        };
    }
    public async Task<IEnumerable<Inventory>> GetInventoryByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);
        
        return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}