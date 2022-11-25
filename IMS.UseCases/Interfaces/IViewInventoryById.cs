using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IViewInventoryById
{
    Task<Inventory> ExecuteAsync(int inventoryId);
}