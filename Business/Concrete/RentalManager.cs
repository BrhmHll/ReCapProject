using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
		IRentalDal _rentalDal;
		ICarService _carService;

		public RentalManager(IRentalDal rentalDal, ICarService carService)
		{
			_rentalDal = rentalDal;
			_carService = carService;
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<List<Rental>> GetAll()
		{
			var result = _rentalDal.GetAll();
			if (result.Count == 0)
			{
				return new ErrorDataResult<List<Rental>>(Messages.Empty);
			}
			return new SuccessDataResult<List<Rental>>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<Rental> GetById(int id)
		{
			var result = _rentalDal.Get(r => r.Id == id);
			if (result == null)
			{
				return new ErrorDataResult<Rental>(Messages.InvalidValue);
			}
			return new SuccessDataResult<Rental>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<List<RentalDetailDto>> GetRentalDetails()
		{
			var result = _rentalDal.GetRentalDetails();
			if (result.Count == 0)
			{
				return new ErrorDataResult<List<RentalDetailDto>>(Messages.Empty);
			}
			return new SuccessDataResult<List<RentalDetailDto>>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<RentalDetailDto> GetRentalDetailsById(int id)
		{
			var result = _rentalDal.GetRentalDetailsById(id);
			if (result == null)
			{
				return new ErrorDataResult<RentalDetailDto>(Messages.Empty);
			}
			return new SuccessDataResult<RentalDetailDto>(result);
		}

		[SecuredOperation("admin,personel")]
		[ValidationAspect(typeof(RentalValidator))]
		public IResult Rental(Rental rental)
		{
			try
			{
				Car car = _carService.GetById(rental.CarId).Data;
				if (car == null)
					return new ErrorResult(Messages.InvalidValue);
				if (car.Available == false)
					return new ErrorResult(Messages.CarNotAvaiable);
				car.Available = false;
				var carUpdateResult = _carService.UpdateCar(car);
				if (!carUpdateResult.Success)
				{
					return carUpdateResult;
				}
				rental.RentDate = DateTime.Now;
				_rentalDal.Add(rental);
				return new SuccessResult(Messages.Successful);
			}
			catch(Exception e)
			{
				return new ErrorResult(e.InnerException.Message);
			}
		}

		[SecuredOperation("admin,personel")]
		[ValidationAspect(typeof(RentalValidator))]
		public IResult Return(Rental rental)
		{
			try
			{
				Rental _rental = _rentalDal.Get(r => r.Id == rental.Id);
				if (_rental == null)
					return new ErrorResult(Messages.InvalidValue);
				_rental.ReturnDate = rental.ReturnDate;

				Car car = _carService.GetById(_rental.CarId).Data;
				car.Available = true;
				_carService.UpdateCar(car);

				_rentalDal.Update(_rental);
				return new SuccessResult(Messages.Successful);
			}
			catch
			{
				return new ErrorResult(Messages.InvalidValue);
			}
		}
	}
}
