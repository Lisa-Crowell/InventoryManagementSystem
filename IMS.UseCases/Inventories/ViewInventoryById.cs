using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

public class ViewInventoryById : IViewInventoryById
{
    private readonly IInventoryRepository _inventoryRepository;
    
    public ViewInventoryById(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    
    public async Task<Inventory> ExecuteAsync(int inventoryId)
    {
        return await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
    }
}

