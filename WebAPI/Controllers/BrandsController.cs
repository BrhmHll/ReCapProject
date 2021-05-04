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
	public class BrandsController : ControllerBase
	{
		private IBrandService _brandService;

		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[HttpGet("getbrands")]
		public IActionResult GetColors()
		{
			var colors = _brandService.GetAll();
			if (colors.Success)
				return Ok(colors);
			return BadRequest(colors);
		}

		[HttpGet("getbrandbyid")]
		public IActionResult GetColorById(int brandId)
		{
			var result = _brandService.GetBrandById(brandId);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("addnewbrand")]
		public IActionResult AddNewColor(Brand brand)
		{
			var result = _brandService.AddNewBrand(brand);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("removebrand")]
		public IActionResult RemoveColor(Brand brand)
		{
			var result = _brandService.RemoveBrand(brand);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("updatebrand")]
		public IActionResult UpdateColor(Brand brand)
		{
			var result = _brandService.UpdateBrand(brand);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}
	}
}
