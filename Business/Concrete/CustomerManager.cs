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
		ICustomerDal customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			this.customerDal = customerDal;
		}

		public IResult AddNewCustomer(Customer customer)
		{
			if (customer.CompanyName.Length < 3)
			{
				return new ErrorResult(Messages.InvalidCompanyName);
			}
			customerDal.Add(customer);
			return new SuccessResult(Messages.Successful);
		}

		public IDataResult<List<Customer>> GetAll()
		{
			var result = customerDal.GetAll();
			if (result == null)
			{
				return new ErrorDataResult<List<Customer>>(Messages.Empty);
			}
			return new SuccessDataResult<List<Customer>>(result);
		}

		public IResult RemoveCustomer(Customer customer)
		{
			customerDal.Delete(customer);
			return new SuccessResult(Messages.Successful);
		}

		public IResult UpdateCustomer(Customer customer)
		{
			customerDal.Update(customer);
			return new SuccessResult(Messages.Successful);
		}
	}
}
