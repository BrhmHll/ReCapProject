using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IBrandService
	{
		IDataResult<List<Brand>> GetAll();
		IResult AddNewBrand(Brand brand);
		IResult UpdateBrand(Brand brand);
		IResult RemoveBrand(Brand brand);
		IDataResult<Brand> GetBrandById(int brandId);
	}
}
