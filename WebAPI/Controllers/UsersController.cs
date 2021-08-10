using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private IUserService2 _userService;

		public UsersController(IUserService2 userService)
		{
			_userService = userService;
		}

		[HttpGet("getusers")]
		public IActionResult GetColors()
		{
			var users = _userService.GetAll();
			if (users.Success)
				return Ok(users);
			return BadRequest(users);
		}

		[HttpPost("addnewuser")]
		public IActionResult AddNewUser(User user)
		{
			var result = _userService.AddNewUser(user);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("removeuser")]
		public IActionResult RemoveColor(User user)
		{
			var result = _userService.RemoveUser(user);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("updateuser")]
		public IActionResult UpdateColor(User user)
		{
			var result = _userService.UpdateUser(user);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpGet("getuserbyid")]
		public IActionResult GetUserById(int userId)
		{
			var user = _userService.GetUserById(userId);
			if(user.Success)
				return Ok(user);
			return BadRequest(user);
		}


	}
}
