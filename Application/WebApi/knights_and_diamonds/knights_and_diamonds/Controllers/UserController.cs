﻿using BLL.Services.Contracts;
using BLL.Services;
using DAL.DataContext;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using DAL.Models;
using DAL.DTOs;

namespace knights_and_diamonds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        /*
				private readonly KnightsAndDiamondsContext context;
				public UnitOfWork unitOfWork { get; set; }
        */
        private readonly KnightsAndDiamondsContext context;
        public IUserService _userService { get; set; }
        public UserController(KnightsAndDiamondsContext context)
        {
            this.context = context;
            _userService = new UserService(this.context);
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            try
            {
                this._userService.AddUser(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("GetUser")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                if (id > 0)
                {
                    return new JsonResult(this._userService.GetUserByID(id));
                }
                else
                {
                    return BadRequest("ID must be bigger than 0");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
