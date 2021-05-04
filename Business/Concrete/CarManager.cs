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
	public class CarManager : ICarService
	{
		ICarDal _cardal;
		public CarManager(ICarDal carDal)
		{
			_cardal = carDal;
		}

		public IResult AddNewCar(Car car)
		{
			try
			{
				if (car.Description.Length > 10 &&
				car.DailyPrice > 0 &&
				car.ModelYear > 1900)
				{
					_cardal.Add(car);
					return new SuccessResult(Messages.AddedNewCar);
				}
				return new ErrorResult(Messages.InvalidValue);
			}
			catch (Exception)
			{

				return new ErrorResult(Messages.Error);
			}
			
		}

		public IDataResult<List<Car>> GetAll()
		{
			var result = _cardal.GetAll();
			if (result.Count == 0)
				return new ErrorDataResult<List<Car>>(Messages.Empty);
			return new SuccessDataResult<List<Car>>(result);
		}

		public IDataResult<Car> GetById(int id)
		{
			var result = _cardal.Get(i => i.CarId == id);
			if (result == null)
				return new ErrorDataResult<Car>(Messages.InvalidValue);
			return new SuccessDataResult<Car>(result);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			var result = _cardal.GetCarDetails();
			if (result == null)
				return new ErrorDataResult<List<CarDetailDto>>(Messages.Empty);
			return new SuccessDataResult<List<CarDetailDto>>(result);
		}

		public IDataResult<CarDetailDto> GetCarDetailsById(int id)
		{
			var result = _cardal.GetCarDetailsById(id);
			if (result == null)
				return new ErrorDataResult<CarDetailDto>(Messages.InvalidValue);
			return new SuccessDataResult<CarDetailDto>(result);
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			var result = _cardal.GetAll(p => p.BrandId==id);
			if (result.Count == 0)
				return new ErrorDataResult<List<Car>>(Messages.InvalidValue);
			return new SuccessDataResult<List<Car>>(result);
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			var result = _cardal.GetAll(p => p.ColorId == id);
			if (result.Count == 0)
				return new ErrorDataResult<List<Car>>(Messages.InvalidValue);
			return new SuccessDataResult<List<Car>>(result);
		}

		public IResult RemoveCar(Car car)
		{
			try
			{
				_cardal.Delete(car);
				return new SuccessResult(Messages.Successful);
			}
			catch
			{
				return new ErrorResult(Messages.InvalidValue);
			}
				
		}

		public IResult UpdateCar(Car car)
		{
			try
			{
				_cardal.Update(car);
				return new SuccessResult(Messages.Successful);
			}
			catch
			{
				return new ErrorResult(Messages.Error);
			}
		}
	}
}
