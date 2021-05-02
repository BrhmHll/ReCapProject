using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, CarsDBContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (CarsDBContext context = new CarsDBContext())
			{

				var result = from car in context.Cars
							 join color in context.Colors
							 on car.ColorId equals color.ColorId
							 join brand in context.Brands
							 on car.BrandId equals brand.BrandId
							 select new CarDetailDto
							 {
								 CarId = car.CarId,
								 ColorName = color.ColorName,
								 DailyPrice = car.DailyPrice,
								 ModelYear = car.ModelYear,
								 Description = car.Description,
								 BrandName = brand.BrandName
							 };

				return result.ToList();
			}
		}

		public CarDetailDto GetCarDetailsById(int id)
		{
			using (CarsDBContext context = new CarsDBContext())
			{

				var result = from car in context.Cars
							 join color in context.Colors
							 on car.ColorId equals color.ColorId
							 join brand in context.Brands
							 on car.BrandId equals brand.BrandId
							 where car.CarId == id
							 select new CarDetailDto
							 {
								 CarId = car.CarId,
								 ColorName = color.ColorName,
								 DailyPrice = car.DailyPrice,
								 ModelYear = car.ModelYear,
								 Description = car.Description,
								 BrandName = brand.BrandName
							 };

				return result.SingleOrDefault();
			}
		}
	}
}
