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
	public class BrandManager : IBrandService
	{
		IBrandDal brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			this.brandDal = brandDal;
		}

		public void AddNewBrand(Brand brand)
		{
			brandDal.Add(brand);
		}

		public List<Brand> GetAll()
		{
			return brandDal.GetAll();
		}
	}
}
