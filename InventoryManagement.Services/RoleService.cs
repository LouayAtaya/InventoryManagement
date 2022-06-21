using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public RoleService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await this._repositoryWrapper.Role.GetAllRolesAsync();
            List<RoleDto> rolesDto = _mapper.Map<List<RoleDto>>(roles);
            return rolesDto;
        }

        public async Task<RoleDto> GetRoleByIdAsync(int roleId)
        {
            var role = await this._repositoryWrapper.Role.GetRoleByIdAsync(roleId);
            if (role == null)
                throw new RoleNotFoundException(roleId);

            return this._mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> CreateRoleAsync(RoleForCreationDto roleForCreationDto)
        {
            var role = _mapper.Map<Role>(roleForCreationDto);

            this._repositoryWrapper.Role.Create(role);

            await this._repositoryWrapper.SaveAsync();

            return this._mapper.Map<RoleDto>(role);
        }

        public async Task UpdateRoleAsync(int roleId, RoleForUpdateDto roleForUpdateDto)
        {
            var role = await this._repositoryWrapper.Role.GetRoleByIdAsync(roleId);
            if (role == null)
                throw new RoleNotFoundException(roleId);

            this._mapper.Map(roleForUpdateDto, role);

            //this._repositoryWrapper.Role.Update(Role);
            await this._repositoryWrapper.SaveAsync();
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var role = await this._repositoryWrapper.Role.GetRoleByIdAsync(roleId);
            if (role == null)
                throw new RoleNotFoundException(roleId);

            this._repositoryWrapper.Role.Delete(role);

            await this._repositoryWrapper.SaveAsync();
        }  
    }
}
