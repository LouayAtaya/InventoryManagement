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
    public class PrivilegeService : IPrivilegeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public PrivilegeService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrivilegeDto>> GetAllPrivilegesAsync()
        {
            var privileges = await this._repositoryWrapper.Privilege.GetAllPrivilegesAsync();
            List<PrivilegeDto> privilegesDto = _mapper.Map<List<PrivilegeDto>>(privileges);
            return privilegesDto;
        }

        public async Task<PrivilegeDto> GetPrivilegeByIdAsync(int privilegeId)
        {
            var privilege = await this._repositoryWrapper.Privilege.GetPrivilegeByIdAsync(privilegeId);
            if (privilege == null)
                throw new PrivilegeNotFoundException(privilegeId);

            return this._mapper.Map<PrivilegeDto>(privilege);
        }

        public async Task<PrivilegeDto> CreatePrivilegeAsync(PrivilegeForCreationDto privilegeForCreationDto)
        {
            var privilege = _mapper.Map<Privilege>(privilegeForCreationDto);

            this._repositoryWrapper.Privilege.Create(privilege);

            await this._repositoryWrapper.SaveAsync();

            return this._mapper.Map<PrivilegeDto>(privilege);
        }

        public async Task UpdatePrivilegeAsync(int privilegeId, PrivilegeForUpdateDto privilegeForUpdateDto)
        {
            var privilege = await this._repositoryWrapper.Privilege.GetPrivilegeByIdAsync(privilegeId);
            if (privilege == null)
                throw new PrivilegeNotFoundException(privilegeId);

            this._mapper.Map(privilegeForUpdateDto, privilege);

            //this._repositoryWrapper.Privilege.Update(Privilege);
            await this._repositoryWrapper.SaveAsync();
        }

        public async Task DeletePrivilegeAsync(int privilegeId)
        {
            var privilege = await this._repositoryWrapper.Privilege.GetPrivilegeByIdAsync(privilegeId);
            if (privilege == null)
                throw new PrivilegeNotFoundException(privilegeId);

            this._repositoryWrapper.Privilege.Delete(privilege);

            await this._repositoryWrapper.SaveAsync();
        }

    }
}
