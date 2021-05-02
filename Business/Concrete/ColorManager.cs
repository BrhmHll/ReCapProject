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
	public class ColorManager : IColorService
	{
		IColorDal colorDal;
		public ColorManager(IColorDal colorDal)
		{
			this.colorDal = colorDal;
		}
		public IResult AddNewColor(Color color)
		{
			if (color.ColorName.Length > 2)
			{
				colorDal.Add(color);
				return new SuccessResult(Messages.Successful);
			}
			return new ErrorResult(Messages.InvalidValue);
		}

		public IDataResult<List<Color>> GetAll()
		{
			var result = colorDal.GetAll();
			if (result == null)
				return new ErrorDataResult<List<Color>>(Messages.Empty);
			return new SuccessDataResult<List<Color>>(result);
		}
	}
}
