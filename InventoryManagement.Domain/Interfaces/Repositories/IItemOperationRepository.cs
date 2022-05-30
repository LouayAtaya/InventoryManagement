using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface IItemOperationRepository: IRepositoryBase<ItemOperation>
    {
        Task<IEnumerable<ItemOperation>> getAllItemOperations();
        Task<IEnumerable<ItemOperation>> GetItemOperationsByItemAsync(int itemId);
        Task<ItemOperation> GetItemOperationByIdAsync(int id);

    }
}
