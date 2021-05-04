using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IRentalService
	{
		IDataResult<List<Rental>> GetAll();
		IDataResult<Rental> GetById(int id);
		IDataResult<List<RentalDetailDto>> GetRentalDetails();
		IDataResult<RentalDetailDto> GetRentalDetailsById(int id);
		IResult Rental(Rental rental);
		IResult Return(Rental rental);
	}
}
