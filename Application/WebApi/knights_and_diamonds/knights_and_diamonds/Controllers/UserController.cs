﻿using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using DAL.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace knights_and_diamonds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

		[AllowAnonymous]
		[Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            try
            {
                await this._userService.AddUser(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [Route("GetUser")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                if (id > 0)
                {
                    var user = await this._userService.GetUserByID(id);
                    var result = new
                    {
                        ID = user.ID,
                        Name = user.Name,
                        SurName = user.SurName,
                        UserName = user.UserName,
                        MainDeckID = user.MainDeckID,
                        Role = user.Role,
                        Email = user.Email,
                    };
                    if (user != null)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return NotFound("User dosent exist");
                    }
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

        [AllowAnonymous]
		[Route("WinsAndLosesCount/{userID}")]
        [HttpGet]
        public async Task<IActionResult> WinsAndLosesCount(int userID)
        {
            try
            {
                var statistcs = await this._userService.WinsAndLosesForUser(userID);
                return Ok(statistcs);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
