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
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;
		public ColorManager(IColorDal colorDal)
		{
			this._colorDal = colorDal;
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(ColorValidator))]
		public IResult AddNewColor(Color color)
		{
			_colorDal.Add(color);
			return new SuccessResult(Messages.Successful);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<List<Color>> GetAll()
		{
			var result = _colorDal.GetAll();
			if (result.Count == 0)
				return new ErrorDataResult<List<Color>>(Messages.Empty);
			return new SuccessDataResult<List<Color>>(result);
		}

		[SecuredOperation("admin,personel")]
		public IDataResult<Color> GetColorById(int colorId)
		{
			var color =_colorDal.Get(c => c.ColorId == colorId);
			if (color == null)
			{
				return new ErrorDataResult<Color>(Messages.InvalidValue);
			}
			return new SuccessDataResult<Color>(color,Messages.Successful);
		}

		[SecuredOperation("admin")]
		public IResult RemoveColor(Color color)
		{
			try
			{
				_colorDal.Delete(color);
				return new SuccessResult(Messages.Successful);
			}
			catch
			{
				return new ErrorResult(Messages.InvalidValue);
			}
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(ColorValidator))]
		public IResult UpdateColor(Color color)
		{
			try
			{
				_colorDal.Update(color);
				return new SuccessResult(Messages.Successful);
			}
			catch
			{
				return new ErrorResult(Messages.InvalidValue);
			}
		}
	}
}
