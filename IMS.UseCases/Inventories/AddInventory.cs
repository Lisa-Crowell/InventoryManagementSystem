using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

public class AddInventory : IAddInventory
{
    private readonly IInventoryRepository _inventoryRepository;
    
    public AddInventory(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    
    public async Task ExecuteAsync(Inventory inventory)
    { 
        await _inventoryRepository.AddInventoryAsync(inventory);
    }
}

