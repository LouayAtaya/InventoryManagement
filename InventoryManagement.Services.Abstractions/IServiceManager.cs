using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IServiceManager
    {
        IItemService ItemService { get; }
        IItemCategoryService ItemCategoryService { get; }
        IWarehouseService WarehouseService { get; }
        IAccountService AccountService { get; }
        ISaleOrderService SaleOrderService { get; }

        IFileManagementService FileManagementService { get; }
    }
}
