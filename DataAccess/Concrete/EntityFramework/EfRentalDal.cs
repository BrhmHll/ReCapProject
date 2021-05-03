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
	public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails()
		{
			using (CarRentalContext context = new CarRentalContext())
			{

				var result = from r in context.Rentals
							 join c in context.Customers
							 on r.CustomerId equals c.UserId
							 select new RentalDetailDto
							 {
								 CarId = r.CarId,
								 Id = r.Id,
								 CompanyName = c.CompanyName,
								 RentDate = r.RentDate,
								 ReturnDate = r.ReturnDate
							 };

				return result.ToList();
			}
		}

		public RentalDetailDto GetRentalDetailsById(int id)
		{
			using (CarRentalContext context = new CarRentalContext())
			{

				var result = from r in context.Rentals
							 join c in context.Customers
							 on r.CustomerId equals c.UserId
							 where r.Id == id
							 select new RentalDetailDto
							 {
								 CarId = r.CarId,
								 Id = r.Id,
								 CompanyName = c.CompanyName,
								 RentDate = r.RentDate,
								 ReturnDate = r.ReturnDate
							 };

				return result.SingleOrDefault();
			}
		}
	}
}
