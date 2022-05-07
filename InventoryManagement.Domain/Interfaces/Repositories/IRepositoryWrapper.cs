using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IItemRepository Item { get; }

        IItemCategoryRepository ItemCategory { get; }

        IWarehouseRepository Warehouse { get; }

        Task SaveAsync();

    }
}
