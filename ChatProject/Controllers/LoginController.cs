using Auth.Jwt;
using AutoMapper;
using Data.Interface;
using Dto.Models.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace ChatProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService repo;
        private readonly IJwtAuthManager jwt;
        private readonly IMapper mapper;

        public LoginController(IUserService repo, IJwtAuthManager jwt, IMapper mapper)
        {
            this.repo = repo;
            this.jwt = jwt;
            this.mapper = mapper;
        }   

        [Authorize]
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(LoginDto user)
        {
            //Console.WriteLine($"{user.email} and {user.password}");
            if(user is null)
            {
                return BadRequest("Please fill in form");
            }
            User existingUser = await repo.GetUserByEmailAsync(user.email);

            if (existingUser is null)
            {

                return NotFound("User not found");
                //return Unauthorized();
            }
            var token = jwt.Authenticate(user, existingUser);
            if (token == null)
            {
                return Unauthorized();
            }



            //await manager.StoreDataAsync(user.email, token);
            //await signalRManager.AddToDataBase();
            return Ok(token);
        }
    }
}
