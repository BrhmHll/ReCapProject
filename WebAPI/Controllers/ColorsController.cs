using Business.Abstract;
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
	public class ColorsController : ControllerBase
	{
		private IColorService _colorService;

		public ColorsController(IColorService colorService)
		{
			this._colorService = colorService;
		}

		[HttpGet("getcolors")]
		public IActionResult GetColors()
		{
			var colors = _colorService.GetAll();
			if (colors.Success)
				return Ok(colors);
			return BadRequest(colors);
		}

		[HttpGet("getcolorbyid")]
		public IActionResult GetColorById(int colorId)
		{
			var result = _colorService.GetColorById(colorId);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}


		[HttpPost("addnewcolor")]
		public IActionResult AddNewColor(Color color)
		{
			var result = _colorService.AddNewColor(color);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("removecolor")]
		public IActionResult RemoveColor(Color color)
		{
			var result = _colorService.RemoveColor(color);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("updatecolor")]
		public IActionResult UpdateColor(Color color)
		{
			var result = _colorService.UpdateColor(color);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}





	}
}
