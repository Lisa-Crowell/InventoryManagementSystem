using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IEditInventory
{
    Task ExecuteAsync(Inventory inventory);
}