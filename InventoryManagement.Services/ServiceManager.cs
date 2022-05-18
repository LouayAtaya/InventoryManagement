using AutoMapper;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IItemService> _lazyItemService;

        private readonly Lazy<IItemCategoryService> _lazyItemCategoryService;

        private readonly Lazy<IWarehouseService> _lazyWarehouseService;

        private readonly Lazy<IAccountService> _lazyAccountService;

        private readonly Lazy<ISaleOrderService> _lazySaleOrderService;


        private readonly Lazy<IFileManagementService> _fileManagementService;

        public ServiceManager(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _lazyItemService = new Lazy<IItemService>(() => new ItemService(repositoryWrapper, mapper));

            _lazyItemCategoryService = new Lazy<IItemCategoryService>(() => new ItemCategoryService(repositoryWrapper,mapper));

            _lazyWarehouseService = new Lazy<IWarehouseService>(() => new WarehouseService(repositoryWrapper,mapper));

            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryWrapper, mapper));

            _lazySaleOrderService = new Lazy<ISaleOrderService>(() => new SaleOrderService(repositoryWrapper, mapper));

            _fileManagementService =new Lazy<IFileManagementService>(()=>new FileManagementService());
        }

        public IItemService ItemService => _lazyItemService.Value;

        public IItemCategoryService ItemCategoryService => _lazyItemCategoryService.Value;

        public IWarehouseService WarehouseService => _lazyWarehouseService.Value;

        public IAccountService AccountService => _lazyAccountService.Value;

        public ISaleOrderService SaleOrderService => _lazySaleOrderService.Value;

        public IFileManagementService FileManagementService => _fileManagementService.Value;

    }
}
