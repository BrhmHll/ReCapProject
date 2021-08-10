using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _cardal;
		public CarManager(ICarDal carDal)
		{
			_cardal = carDal;
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(CarValidator))]
		public IResult AddNewCar(Car car)
		{
			var result = BusinessRules.Run(CheckIfCarDescriptionExists(car.Description));
			if (result.Success == false)
			{
				return result;
			}
			if (CheckIfCarIdExists(car.CarId).Success)
			{
				return new ErrorResult(Messages.CarExists);
			}
			_cardal.Add(car);
			return new SuccessResult(Messages.AddedNewCar);			
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<List<Car>> GetAll()
		{
			var result = _cardal.GetAll();
			if (result.Count == 0)
				return new ErrorDataResult<List<Car>>(Messages.Empty);
			return new SuccessDataResult<List<Car>>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<Car> GetById(int id)
		{
			var result = _cardal.Get(i => i.CarId == id);
			if (result == null)
				return new ErrorDataResult<Car>(Messages.InvalidValue);
			return new SuccessDataResult<Car>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			var result = _cardal.GetCarDetails();
			if (result == null)
				return new ErrorDataResult<List<CarDetailDto>>(Messages.Empty);
			return new SuccessDataResult<List<CarDetailDto>>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<CarDetailDto> GetCarDetailsById(int id)
		{
			var result = _cardal.GetCarDetailsById(id);
			if (result == null)
				return new ErrorDataResult<CarDetailDto>(Messages.InvalidValue);
			return new SuccessDataResult<CarDetailDto>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			var result = _cardal.GetAll(p => p.BrandId==id);
			if (result.Count == 0)
				return new ErrorDataResult<List<Car>>(Messages.InvalidValue);
			return new SuccessDataResult<List<Car>>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			var result = _cardal.GetAll(p => p.ColorId == id);
			if (result.Count == 0)
				return new ErrorDataResult<List<Car>>(Messages.InvalidValue);
			return new SuccessDataResult<List<Car>>(result);
		}
		[SecuredOperation("admin")]
		public IResult RemoveCar(Car car)
		{
			if (!CheckIfCarIdExists(car.CarId).Success)
			{
				return new ErrorResult(Messages.CarNotFound);
			}
			_cardal.Delete(car);
			return new SuccessResult(Messages.Successful);

		}

		[SecuredOperation("admin,personel")]
		[ValidationAspect(typeof(CarValidator))]
		public IResult UpdateCar(Car car)
		{
			if (!CheckIfCarIdExists(car.CarId).Success)
			{
				return new ErrorResult(Messages.CarNotFound);
			}
			_cardal.Update(car);
			return new SuccessResult();
		}


		// Private Methods

		private IResult CheckIfCarDescriptionExists(string carDescription)
		{
			if (_cardal.GetAll(c => c.Description == carDescription).Any())
			{
				return new ErrorResult(Messages.CarNameExists);
			}
			return new SuccessResult();
		}

		private IResult CheckIfCarIdExists(int carId)
		{
			if (_cardal.GetAll(c => c.CarId == carId).Any())
			{
				return new SuccessResult();
			}
			return new ErrorResult(Messages.CarExists);

		}



	}
}
