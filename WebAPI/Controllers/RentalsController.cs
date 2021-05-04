﻿using Business.Abstract;
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
	public class RentalsController : ControllerBase
	{
		IRentalService _rentalService;

		public RentalsController(IRentalService rentalService)
		{
			_rentalService = rentalService;
		}

		[HttpGet("getrentals")]
		public IActionResult GetAll()
		{
			var result = _rentalService.GetAll();
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}


		[HttpPost("rental")]
		public IActionResult Rental(Rental rental)
		{
			var result = _rentalService.Rental(rental);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("return")]
		public IActionResult Return(Rental rental)
		{
			var result = _rentalService.Return(rental);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpGet("getallrentaldetails")]
		public IActionResult GetAllRentalDetails()
		{
			var result = _rentalService.GetRentalDetails();
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpGet("getrentaldetailsbyid")]
		public IActionResult GetRentalDetailsById(int rentalId)
		{
			var result = _rentalService.GetRentalDetailsById(rentalId);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}


	}
}
