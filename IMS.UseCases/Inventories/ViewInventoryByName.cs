using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

public class ViewInventoryByName : IViewInventoryByName
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoryByName(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
    {
        return await _inventoryRepository.GetInventoryByNameAsync(name);
    }
}