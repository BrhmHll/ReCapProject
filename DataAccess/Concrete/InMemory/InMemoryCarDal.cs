using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;
		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
				//new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 120, Description = "Family Size", ModelYear = 2018 },
				//new Car{CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 100, Description = "Chip", ModelYear = 2013 },
				//new Car{CarId = 3, BrandId = 2, ColorId = 1, DailyPrice = 300, Description = "Sport Car", ModelYear = 2020 },
				//new Car{CarId = 4, BrandId = 3, ColorId = 3, DailyPrice = 150, Description = "Standart", ModelYear = 2018 },
				//new Car{CarId = 5, BrandId = 3, ColorId = 4, DailyPrice = 160, Description = "Standart", ModelYear = 2019 }
			};
		}
		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			_cars.Remove(CarToDelete);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Car GetById(Car car)
		{
			return _cars.SingleOrDefault(c => c.CarId == car.CarId);
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public CarDetailDto GetCarDetailsById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Car car)
		{
			Car CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			//CarToUpdate.CarId = car.CarId;
			CarToUpdate.BrandId = car.BrandId;
			CarToUpdate.ColorId = car.ColorId;
			CarToUpdate.DailyPrice = car.DailyPrice;
			CarToUpdate.Description = car.Description;
			CarToUpdate.ModelYear = car.ModelYear;
		}
	}
}
