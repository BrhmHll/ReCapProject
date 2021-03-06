using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserService2
	{
		IDataResult<List<User>> GetAll();
		IDataResult<User> GetUserById(int userId);
		IResult AddNewUser(User user);
		IResult RemoveUser(User user);
		IResult UpdateUser(User user);
	}
}
