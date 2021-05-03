using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class RentalManager : IRentalService
	{
		IRentalDal rentalDal;
		public RentalManager(IRentalDal rentalDal)
		{
			this.rentalDal = rentalDal;
		}

		public IDataResult<List<Rental>> GetAll()
		{
			var result = rentalDal.GetAll();
			if (result == null)
			{
				return new ErrorDataResult<List<Rental>>(Messages.Empty);
			}
			return new SuccessDataResult<List<Rental>>(result);
		}

		public IDataResult<Rental> GetById(int id)
		{
			var result = rentalDal.Get(r => r.Id == id);
			if (result == null)
			{
				return new ErrorDataResult<Rental>(Messages.InvalidValue);
			}
			return new SuccessDataResult<Rental>(result);
		}

		public IDataResult<List<RentalDetailDto>> GetRentalDetails()
		{
			var result = rentalDal.GetRentalDetails();
			if (result == null)
			{
				return new ErrorDataResult<List<RentalDetailDto>>(Messages.Empty);
			}
			return new SuccessDataResult<List<RentalDetailDto>>(result);
		}

		public IDataResult<RentalDetailDto> GetRentalDetailsById(int id)
		{
			throw new NotImplementedException();
		}

		public IResult Rental(Rental rental)
		{
			rentalDal.Add(rental);
			return new SuccessResult(Messages.Successful);
		}
	}
}
