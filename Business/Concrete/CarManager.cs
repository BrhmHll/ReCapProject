using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

		public void AddNewCar(Car car)
		{
			if (car.Description.Length > 10 && car.DailyPrice > 0 && car.ModelYear > 1900)
			{
				_cardal.Add(car);
			}
			else
				Console.WriteLine("Bilgiler eklenemedi!");
		}

		public List<Car> GetAll()
		{
			// Business Codes
			// if statments
			// authority control
			return _cardal.GetAll();
		}

		public List<Car> GetCarsByBrandId(int id)
		{
			return _cardal.GetAll(p => p.BrandId==id);
		}

		public List<Car> GetCarsByColorId(int id)
		{
			return _cardal.GetAll(p => p.ColorId == id);
		}
	}
}
