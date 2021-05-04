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
	public class CustomersController : ControllerBase
	{

		private ICustomerService _customerService;

		public CustomersController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet("getcustomers")]
		public IActionResult GetCustomers()
		{
			var customers = _customerService.GetAll();
			if (customers.Success)
				return Ok(customers);
			return BadRequest(customers);
		}

		[HttpPost("addnewcustomer")]
		public IActionResult AddNewCustomer(Customer customer)
		{
			var result = _customerService.AddNewCustomer(customer);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("removecustomer")]
		public IActionResult RemoveCustomer(Customer customer)
		{
			var result = _customerService.RemoveCustomer(customer);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("updatecustomer")]
		public IActionResult UpdateCustomer(Customer customer)
		{
			var result = _customerService.UpdateCustomer(customer);
			if (result.Success)
				return Ok(result);
			return BadRequest(result);
		}

		[HttpGet("getcustomerbyid")]
		public IActionResult GetCustomerById(int customerId)
		{
			var user = _customerService.GetUserById(customerId);
			if (user.Success)
				return Ok(user);
			return BadRequest(user);
		}


	}
}
