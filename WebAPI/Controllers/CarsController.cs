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
	public class CarsController : ControllerBase
	{
		private ICarService _carService;

		public CarsController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _carService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getcarsdetails")]
		public IActionResult GetCarDetail()
		{
			var cars = _carService.GetCarDetails();
			if (cars.Success)
				return Ok(cars);
			return BadRequest(cars);

		}

		[HttpGet("getcarsbycolorid")]
		public IActionResult GetCarsByColorId(int colodId)
		{
			var cars = _carService.GetCarsByColorId(colodId);
			if (cars.Success)
				return Ok(cars);
			return BadRequest(cars);

		}

		[HttpGet("getcarsbybrandid")]
		public IActionResult GetCarsByBrandId(int brandId)
		{
			var cars = _carService.GetCarsByBrandId(brandId);
			if (cars.Success)
				return Ok(cars);
			return BadRequest(cars);
		}

		[HttpGet("getcardetailbyid")]
		public IActionResult GetCarDetailById(int carId)
		{
			var carDetail = _carService.GetCarDetailsById(carId);
			if (carDetail.Success)
				return Ok(carDetail);
			return BadRequest(carDetail);
		}

		[HttpGet("getcarbyid")]
		public IActionResult GetCarById(int carId)
		{
			var gettedCar = _carService.GetById(carId);
			if (gettedCar.Success)
				return Ok(gettedCar);
			return BadRequest(gettedCar);
		}

		[HttpPost("addnewcar")]
		public IActionResult AddNewCar(Car car)
		{
			var result = _carService.AddNewCar(car);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("updatecar")]
		public IActionResult UpdateCar(Car car)
		{
			var result = _carService.UpdateCar(car);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("removecar")]
		public IActionResult RemoveCar(Car car)
		{
			var result = _carService.RemoveCar(car);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}


	}
}
