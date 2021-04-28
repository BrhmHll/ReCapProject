using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
				new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 120, Description = "Family Size", ModelYear = 2018 },
				new Car{Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 100, Description = "Chip", ModelYear = 2013 },
				new Car{Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 300, Description = "Sport Car", ModelYear = 2020 },
				new Car{Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 150, Description = "Standart", ModelYear = 2018 },
				new Car{Id = 5, BrandId = 3, ColorId = 4, DailyPrice = 160, Description = "Standart", ModelYear = 2019 }
			};
		}
		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car CarToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
			_cars.Remove(CarToDelete);
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public Car GetById(Car car)
		{
			return _cars.SingleOrDefault(c => c.Id == car.Id);
		}

		public void Update(Car car)
		{
			Car CarToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
			CarToUpdate.Id = car.Id;
			CarToUpdate.BrandId = car.BrandId;
			CarToUpdate.ColorId = car.ColorId;
			CarToUpdate.DailyPrice = car.DailyPrice;
			CarToUpdate.Description = car.Description;
			CarToUpdate.ModelYear = car.ModelYear;
		}
	}
}
