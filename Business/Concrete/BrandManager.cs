using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

		public IResult AddNewBrand(Brand brand)
		{
			if (brand.BrandName.Length > 2)
			{
				brandDal.Add(brand);
				return new SuccessResult(Messages.Successful);
			}
			return new ErrorResult(Messages.InvalidValue);
			
		}

		public IDataResult<List<Brand>> GetAll()
		{
			var result = brandDal.GetAll();
			if (result == null)
				return new ErrorDataResult<List<Brand>>(Messages.Empty);
			return new SuccessDataResult<List<Brand>>(result);
		}
	}
}
