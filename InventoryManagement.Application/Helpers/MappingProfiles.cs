using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Warehouse
            CreateMap<Warehouse, WarehouseDto>()
                .ForMember(dist=> dist.Name, 
                    opt=>opt.MapFrom(src=>src.Name))
                .ReverseMap();
            CreateMap<WarehouseForCreationDto, Warehouse>();
            CreateMap<WarehouseForUpdateDto, Warehouse>();

            //ItemCategory
            CreateMap<ItemCategory, ItemCategoryDto>()
                .ReverseMap();
            CreateMap<ItemCategoryForCreationDto, ItemCategory>();
            CreateMap<ItemCategoryForUpdateDto, ItemCategory>();

            //Item
            CreateMap<Item, ItemDto>()
                .ForMember(dist=>dist.ItemCategoryName, 
                    op=>op.MapFrom(src=>src.ItemCategory.Name));  //try for member, we can remove it as mapping convisions by name
            CreateMap<Item, ItemDetailsDto>();
            CreateMap<WarehouseItem, WarehouseItemDto>();
            CreateMap<ItemImage, ItemImageDto>();
            CreateMap<ItemForCreationDto, Item>();
            CreateMap<WarehouseItemForCreationDto, WarehouseItem>();
            CreateMap<ItemImageForCreationDto, ItemImage>();
            CreateMap<ItemForUpdateDto, Item>();
            CreateMap<WarehouseItemForUpdateDto, WarehouseItem>();
            CreateMap<ItemImageForUpdateDto, ItemImage>();

            //Account
            CreateMap<Account, AccountDto>();
            CreateMap<Account, AccountDetailDto>();
            CreateMap<AccountForCreationDto, Account>();
            CreateMap<AccountForUpdateDto, Account>();

            //SaleOrder
            CreateMap<SaleOrder, SaleOrderDto>();
            CreateMap<SaleOrderForCreationDto, SaleOrder>();
            CreateMap<SaleOrderForUpdateDto, SaleOrder>();
            CreateMap<SaleOrderItem, SaleOrderItemDto>();
            CreateMap<SaleOrderItemForCreationDto, SaleOrderItem>();
            CreateMap<SaleOrderItemForUpdateDto, SaleOrderItem>();

            //ItemOperation
            CreateMap<ItemOperation, ItemOperationDto>();
            CreateMap<ItemOperationForCreationDto, ItemOperation>();
            CreateMap<ItemOperationForUpdateDto, ItemOperation>();

            //User
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<Member, MemberDto>();
            CreateMap<MemberForCreationDto, Member>();
            CreateMap<MemberForUpdateDto, Member>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleForCreationDto, UserRole>();
            CreateMap<UserRoleForUpdateDto, UserRole>();

            //Role
            CreateMap<Role, RoleDto>();
            CreateMap<RoleForCreationDto, Role>();
            CreateMap<RoleForUpdateDto, Role>();
            CreateMap<RolePrivilege, RolePrivilegeDto>();
            CreateMap<RolePrivilegeForCreationDto, RolePrivilege>();
            CreateMap<RolePrivilegeForUpdateDto, RolePrivilege>();

            //Privilege
            CreateMap<Privilege, PrivilegeDto>();
            CreateMap<PrivilegeForCreationDto, Privilege>();
            CreateMap<PrivilegeForUpdateDto, Privilege>();

        }
    }
}
