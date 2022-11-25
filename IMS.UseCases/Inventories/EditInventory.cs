using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

public class EditInventory : IEditInventory
{
    private readonly IInventoryRepository _inventoryRepository;
    
    public EditInventory(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    
    public async Task ExecuteAsync(Inventory inventory)
    {
        await _inventoryRepository.UpdateInventoryAsync(inventory);
    }
}