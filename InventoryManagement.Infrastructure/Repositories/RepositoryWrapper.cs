﻿
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Infrastructure.Data;
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

        public async Task SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }

        
    }
}