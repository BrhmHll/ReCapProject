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
	public class UserManager : IUserService
	{
		IUserDal userDal;

		public UserManager(IUserDal userDal)
		{
			this.userDal = userDal;
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
			userDal.Add(user);
			return new SuccessResult(Messages.Successful);
		}

		public IDataResult<List<User>> GetAll()
		{
			var result = userDal.GetAll();
			if (result == null)
			{
				return new ErrorDataResult<List<User>>(Messages.Empty);
			}
			return new SuccessDataResult<List<User>>(result);
		}

		public IResult RemoveUser(User user)
		{
			userDal.Delete(user);
			return new SuccessResult(Messages.Successful);
		}

		public IResult UpdateUser(User user)
		{
			userDal.Update(user);
			return new SuccessResult(Messages.Successful);
		}
	}
}
