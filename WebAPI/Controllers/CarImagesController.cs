using Business.Abstract;
using Business.Constants;
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
	public class CarImagesController : ControllerBase
	{
		ICarImageService _carImageService;

		public CarImagesController(ICarImageService carImageService)
		{
			_carImageService = carImageService;
		}


		[HttpPost("addnewcarimagelink")]
		public IActionResult AddNewCarImageLink([FromForm] CarImage carImage)
		{
			var result = _carImageService.AddImageLink(carImage);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(Messages.Successful);
		}

		[HttpPost("updatecarimagelink")]
		public IActionResult UpdateCarImageLink([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
		{
			var carImageResult = _carImageService.Get(id);
			var result = _carImageService.UpdateImageLink(carImageResult.Data);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(Messages.Successful);
		}

		[HttpPost("deletecarimagelink")]
		public IActionResult DeleteCarImageLink(CarImage carImage)
		{
			var result = _carImageService.DeleteImageLink(carImage);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(Messages.Successful);
		}


		[HttpGet("getallimagesbycarid")]
		public IActionResult GetAllCarImagesByCarId(int carId)
		{
			var images = _carImageService.GetAllImagesByCarId(carId);
			if (!images.Success)
			{
				return BadRequest(images);
			}
			return Ok(images); 
		}

		[HttpGet("getimagebycarid")]
		public IActionResult GetCarImageByCarId(int carId)
		{
			var image = _carImageService.GetImageByCarId(carId);
			if (!image.Success)
			{
				return BadRequest(image);
			}
			return Ok(image);
		}

		[HttpPost("addnewcarimage")]
		public IActionResult AddNewCarImage([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
		{
			var result = _carImageService.AddImage(file, carImage);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(Messages.Successful);
		}

		[HttpPost("updatecarimage")]
		public IActionResult UpdateCarImage([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name =("Id"))] int id)
		{
			var carImageResult = _carImageService.Get(id);
			var result = _carImageService.UpdateImage(file, carImageResult.Data);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(Messages.Successful);
		}

		[HttpPost("deletecarimage")]
		public IActionResult DeleteCarImage(CarImage carImage)
		{
			var result = _carImageService.DeleteImage(carImage);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(Messages.Successful);
		}


	}
}
