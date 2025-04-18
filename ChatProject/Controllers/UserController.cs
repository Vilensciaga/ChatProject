using Auth.EncryptionMethods;
using AutoMapper;
using Data.Interface;
using Data.Service;
using Dto.Models.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace ChatProject.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService repository;
        private readonly IMapper mapper;
        //private readonly IJwtAuthManager jwt;

        public UserController(IUserService repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
         
        }
        

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = (await repository.GetUsersAsync());
            var usersDto = mapper.Map<IEnumerable<UserDto>>(users);
            return usersDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserAsync([FromRoute] int id)
        {
            if (id >= 0)
            {
                var user = (await repository.GetUserAsync(id));
                var userDto = mapper.Map<UserDto>(user);
                return userDto;
            }
            else
            {
                return BadRequest("No Id provided");

            }
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] CreateUserDto userDto)
        {
           userDto.password = Encryption.EncryptPassword(userDto.password);
           User user = await repository.CreateUserAsync(userDto);

            if (user == null || user.Id == 0)
            {
                return BadRequest("User creation failed, no ID returned.");
            }

            return CreatedAtAction(nameof(GetUserAsync), mapper.Map<UserDto>(user));
        }

        [Authorize]
        [HttpPut("{id}")]
        //[EnableCors("*")]
        public async Task<ActionResult<UpdateUserDto>> UpdateUserAsync(UpdateUserDto userDto, [FromRoute] int id)
        {
            User existingUser = await repository.GetUserAsync(id);
            if (existingUser is null)
            {
                return NotFound();
            }

            return await repository.UpdateUserAsync(existingUser.Id, userDto);

            //return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync([FromRoute] int id)
        {
            User existingUser = await repository.GetUserAsync(id);
            if (existingUser is null)
            {
                return NotFound();
            }

            await repository.DeleteUserAsync(id);

            return NoContent();
        }

    }
}
