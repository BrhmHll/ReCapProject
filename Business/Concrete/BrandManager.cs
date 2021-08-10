using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(BrandValidator))]
		public IResult AddNewBrand(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Messages.Successful);

		}

		[SecuredOperation("admin,personel")]
		public IDataResult<List<Brand>> GetAll()
		{
			var result = _brandDal.GetAll();
			if (result == null)
				return new ErrorDataResult<List<Brand>>(Messages.Empty);
			return new SuccessDataResult<List<Brand>>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<Brand> GetBrandById(int brandId)
		{
			var brand = _brandDal.Get(b => b.BrandId == brandId);
			if (brand == null)
			{
				return new ErrorDataResult<Brand>(Messages.InvalidValue);
			}
			return new SuccessDataResult<Brand>(brand, Messages.Successful);
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(BrandValidator))]
		public IResult RemoveBrand(Brand brand)
		{
			try
			{
				_brandDal.Delete(brand);
				return new SuccessResult(Messages.Successful);
			}
			catch
			{
				return new ErrorResult(Messages.InvalidValue);
			}
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(BrandValidator))]
		public IResult UpdateBrand(Brand brand)
		{
			try
			{
				_brandDal.Update(brand);
				return new SuccessResult(Messages.Successful);
			}
			catch
			{
				return new ErrorResult(Messages.InvalidValue);
			}
		}
	}
}
