using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsDBContext>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails()
		{
			using (CarsDBContext context = new CarsDBContext())
			{

				var result = from r in context.Rentals
							 join c in context.Customers
							 on r.CustomerId equals c.UserId
							 join car in context.Cars
							 on r.CarId equals car.CarId
							 join color in context.Colors
							 on car.ColorId equals color.ColorId
							 join brand in context.Brands
							 on car.BrandId equals brand.BrandId
							 select new RentalDetailDto
							 {
								 Id = r.Id,
								 CompanyName = c.CompanyName,
								 RentDate = r.RentDate,
								 ReturnDate = r.ReturnDate,
								 CarDescription = car.Description,
								 DailyPrice = car.DailyPrice,
								 BrandName = brand.BrandName,
								 ColorName = color.ColorName
							 };

				return result.ToList();
			}
		}

		public RentalDetailDto GetRentalDetailsById(int id)
		{
			using (CarsDBContext context = new CarsDBContext())
			{
				var result = from r in context.Rentals
							 join c in context.Customers
							 on r.CustomerId equals c.UserId
							 join car in context.Cars
							 on r.CarId equals car.CarId
							 join color in context.Colors
							 on car.ColorId equals color.ColorId
							 join brand in context.Brands
							 on car.BrandId equals brand.BrandId
							 where r.Id == id
							 select new RentalDetailDto
							 {
								 Id = r.Id,
								 CompanyName = c.CompanyName,
								 RentDate = r.RentDate,
								 ReturnDate = r.ReturnDate,
								 CarDescription = car.Description,
								 DailyPrice = car.DailyPrice,
								 BrandName = brand.BrandName,
								 ColorName = color.ColorName
							 };

				return result.SingleOrDefault();
			}
		}
	}
}
