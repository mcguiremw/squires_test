using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCode.Data;
using AppCode.Data.Entities;
using AppCode.Data.Models;
using AppCode.Data.Repository;
using AppCode.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public UserController(IUserRepository userRepository, ITokenService tokenService)
        {          
            _tokenService = tokenService;
            _userRepository = userRepository;
        }
        [Route("register")]
        [HttpPost]
        public Task<bool> Register(User user)
        {
            return _userRepository.Save(user);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel credentials)
        {
            var data = await _userRepository.GetUser(credentials.Name, credentials.Password);

            if (data != null )
            {
                return Ok(_tokenService.CreateToken(credentials.Name));
            }
            return BadRequest();

        }

    }
}
