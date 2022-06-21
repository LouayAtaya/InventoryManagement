using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        public IItemRepository Item { get; }

        public IItemCategoryRepository ItemCategory { get; }

        public IWarehouseRepository Warehouse { get; }

        public IAccountRepository Account { get; }

        public ISaleOrderRepository SaleOrder { get; }
        public IItemOperationRepository ItemOperation { get; }

        public IRoleRepository Role { get; }
        public IUserRepository User { get; }
        public IPrivilegeRepository Privilege { get; }

        DbContext DbContext { get; }


        Task SaveAsync();

        void DetachEntry<T>(T o);

        void ModifayEntry<T>(T o);

    }
}
