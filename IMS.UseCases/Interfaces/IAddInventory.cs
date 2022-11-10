using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IAddInventory
{
    Task ExecuteAsync(Inventory inventory);
}