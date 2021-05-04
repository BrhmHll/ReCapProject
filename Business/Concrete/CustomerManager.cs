using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		public IResult AddNewCustomer(Customer customer)
		{
			if (customer.CompanyName.Length < 3)
			{
				return new ErrorResult(Messages.InvalidCompanyName);
			}
			_customerDal.Add(customer);
			return new SuccessResult(Messages.Successful);
		}

		public IDataResult<List<Customer>> GetAll()
		{
			var result = _customerDal.GetAll();
			if (result == null)
			{
				return new ErrorDataResult<List<Customer>>(Messages.Empty);
			}
			return new SuccessDataResult<List<Customer>>(result);
		}

		public IDataResult<Customer> GetUserById(int customerId)
		{
			var customer = _customerDal.Get(u => u.UserId == customerId);
			if (customer == null)
				return new ErrorDataResult<Customer>(customer);
			return new SuccessDataResult<Customer>(customer);
		}

		public IResult RemoveCustomer(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Messages.Successful);
		}

		public IResult UpdateCustomer(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult(Messages.Successful);
		}
	}
}
