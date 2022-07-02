using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Services.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await this._repositoryWrapper.User.GetAllUsersAsync();
            List<UserDto> UsersDto = _mapper.Map<List<UserDto>>(users);
            return UsersDto;
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var users = await this._repositoryWrapper.User.GetUserByIdAsync(userId);
            if (users == null)
                throw new UserNotFoundException(userId);

            return this._mapper.Map<UserDto>(users);
        }

        public Task<IEnumerable<RoleDto>> GetRolesByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticatedResponseDto> Login(LoginUserDto loginUser)
        {
            var user = await this._repositoryWrapper.User.GetUserByNameAndPassword(loginUser.Username,loginUser.Password);
            if (user == null)
                throw new InvalidLoginCredentialsException();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@5215"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                //new Claim("username",user.Username),
                new Claim(ClaimTypes.Name, user.Username),
            };

            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            var tokeOptions = new JwtSecurityToken(
                issuer: "https://InventoryManagement.com",
                audience: "https://InventoryManagement.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return new AuthenticatedResponseDto { Token = tokenString };
        }


        public async Task<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto)
        {
            var user = _mapper.Map<User>(userForCreationDto);

            this._repositoryWrapper.User.Create(user);

            await this._repositoryWrapper.SaveAsync();

            return this._mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAsync(int userId, UserForUpdateDto userForUpdateDto)
        {
            var user = await this._repositoryWrapper.User.GetUserByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            this._mapper.Map(userForUpdateDto, user);

            //this._repositoryWrapper.User.Update(User);
            await this._repositoryWrapper.SaveAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await this._repositoryWrapper.User.GetUserByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            this._repositoryWrapper.User.Delete(user);

            await this._repositoryWrapper.SaveAsync();
        }
    }
}
