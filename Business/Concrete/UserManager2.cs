using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class UserManager2 : IUserService2
	{
		IUserDal _userDal;

		public UserManager2(IUserDal userDal)
		{
			this._userDal = userDal;
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(UserValidator))]
		public IResult AddNewUser(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(Messages.Successful);
		}

		[SecuredOperation("admin")]
		public IDataResult<List<User>> GetAll()
		{
			var result = _userDal.GetAll();
			if (result == null)
			{
				return new ErrorDataResult<List<User>>(Messages.Empty);
			}
			return new SuccessDataResult<List<User>>(result);
		}

		[SecuredOperation("admin")]
		public IDataResult<User> GetUserById(int userId)
		{
			var user = _userDal.Get(u => u.Id == userId);
			if (user == null)
				return new ErrorDataResult<User>(user);
			return new SuccessDataResult<User>(user);
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(UserValidator))]
		public IResult RemoveUser(User user)
		{
			try
			{
				_userDal.Delete(user);
				return new SuccessResult(Messages.Successful);
			}
			catch(DbUpdateConcurrencyException)
			{
				return new ErrorResult(Messages.InvalidValue);
			}
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(UserValidator))]
		public IResult UpdateUser(User user)
		{
			try
			{
				_userDal.Update(user);
				return new SuccessResult(Messages.Successful);
			}
			catch (DbUpdateConcurrencyException)
			{
				return new ErrorResult(Messages.InvalidValue);
			}
		}
	}
}
