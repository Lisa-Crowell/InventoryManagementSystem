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

    public async Task<bool> ExistsAsync(Inventory inventory)
    {
        return await Task.FromResult(_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)));
    }

    public Task AddInventoryAsync(Inventory inventory)
    {
        if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _inventories.Max(x => x.InventoryId);
        inventory.InventoryId = maxId + 1;
        
        _inventories.Add(inventory);
        
        return Task.CompletedTask;
    }

    public Task UpdateInventoryAsync(Inventory inventory)
    {
        if (_inventories.Any(x => x.InventoryId == inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var inventoryToUpdate = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
        if (inventoryToUpdate != null)
        {
            inventoryToUpdate.InventoryName = inventory.InventoryName;
            inventoryToUpdate.Quantity = inventory.Quantity;
            inventoryToUpdate.Price = inventory.Price;    
        }
        return Task.CompletedTask;
    }

    public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
    {
        var inventory = _inventories.FirstOrDefault(x => x.InventoryId == inventoryId);
        var newInventory = new Inventory
        {
            InventoryId = inventory.InventoryId,
            InventoryName = inventory.InventoryName,
            Quantity = inventory.Quantity,
            Price = inventory.Price
        };
        return await Task.FromResult(newInventory);
    }
}