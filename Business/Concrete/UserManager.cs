using Business.Abstract;
using Business.Constants;
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
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			this._userDal = userDal;
		}

		public IResult AddNewUser(User user)
		{
			if (!user.Email.EndsWith(".com"))
			{
				return new ErrorResult(Messages.InvalidEmail);
			}
			if (user.FirstName.Length < 3 | user.LastName.Length < 2)
			{
				return new ErrorResult(Messages.InvalidName);
			}
			if (user.Password.Length < 8)
			{
				return new ErrorResult(Messages.InvalidPassword);
			}
			_userDal.Add(user);
			return new SuccessResult(Messages.Successful);
		}

		public IDataResult<List<User>> GetAll()
		{
			var result = _userDal.GetAll();
			if (result == null)
			{
				return new ErrorDataResult<List<User>>(Messages.Empty);
			}
			return new SuccessDataResult<List<User>>(result);
		}

		public IDataResult<User> GetUserById(int userId)
		{
			var user = _userDal.Get(u => u.Id == userId);
			if (user == null)
				return new ErrorDataResult<User>(user);
			return new SuccessDataResult<User>(user);
		}

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
