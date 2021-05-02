using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarService
	{
		List<Car> GetAll();
		Car GetById(int id);
		List<Car> GetCarsByBrandId(int id);
		List<Car> GetCarsByColorId(int id);
		List<CarDetailDto> GetCarDetails();
		CarDetailDto GetCarDetailsById(int id);
		void AddNewCar(Car car);

	}
}
