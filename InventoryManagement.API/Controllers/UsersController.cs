using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await this._serviceManager.UserService.GetAllUsersAsync();

            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await this._serviceManager.UserService.GetUserByIdAsync(userId);

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto userForCreationDto)
        {
            var user = await this._serviceManager.UserService.CreateUserAsync(userForCreationDto);

            return CreatedAtAction("GetUserById", new { userId = user.Id }, user);
        }

        // POST api/<UsersController>
        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserDto registerUserDto)
        {
            var user=await this._serviceManager.UserService.Register(registerUserDto);

            return CreatedAtAction("GetUserById", new { userId = user.Id }, user);
        }

        // POST api/<UsersController>
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
        {
            var authenticatedResponse = await this._serviceManager.UserService.Login(loginUser);

            return Ok(authenticatedResponse);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{userId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Put(int userId, [FromBody] UserForUpdateDto userForUpdateDto)
        {
            await this._serviceManager.UserService.UpdateUserAsync(userId, userForUpdateDto);

            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            await this._serviceManager.UserService.DeleteUserAsync(userId);

            return Ok();
        }

    }
}
