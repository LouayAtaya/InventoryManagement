
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private InventoryManagementContext _dbContext;

        private IItemRepository _itemRepository;

        private IItemCategoryRepository _itemCategoryRepository;

        private IWarehouseRepository _warehouseRepository;

        private IAccountRepository _accountRepository;

        private ISaleOrderRepository _saleOrderRepository;

        private IItemOperationRepository _itemOperationRepository;

        public RepositoryWrapper(InventoryManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IItemRepository Item
        {
            get
            {
                if (this._itemRepository == null)
                    _itemRepository= new ItemRepository(_dbContext);
                return _itemRepository;
            }
        }

        public IItemCategoryRepository ItemCategory
        {
            get
            {
                if (this._itemCategoryRepository == null)
                    _itemCategoryRepository = new ItemCategoryRepository(_dbContext);
                return _itemCategoryRepository;
            }

        }

        public IWarehouseRepository Warehouse
        {
            get
            {
                if (this._warehouseRepository == null)
                    _warehouseRepository = new WarehouseRepository(_dbContext);
                return _warehouseRepository;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (this._accountRepository == null)
                    _accountRepository = new AccountRepository(_dbContext);
                return _accountRepository;
            }
        }

        public ISaleOrderRepository SaleOrder
        {
            get
            {
                if (this._saleOrderRepository == null)
                    _saleOrderRepository = new SaleOrderRepository(_dbContext);
                return _saleOrderRepository;
            }
        }

        public IItemOperationRepository ItemOperation
        {
            get
            {
                if (this._itemOperationRepository == null)
                    _itemOperationRepository = new ItemOperationRepository(_dbContext);
                return _itemOperationRepository;
            }
        }

        public async Task SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }

        public void DetachEntry<T>(T o)
        {
            _dbContext.Entry(o).State = EntityState.Detached;
        }

        public void ModifayEntry<T>(T o)
        {
            _dbContext.Entry(o).State = EntityState.Modified;
        }

        public DbContext DbContext { get { return this._dbContext; } }


    }
}
