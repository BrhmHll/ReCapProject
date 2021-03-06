using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IColorService
	{
		IDataResult<List<Color>> GetAll();
		IResult AddNewColor(Color color);
		IResult UpdateColor(Color color);
		IResult RemoveColor(Color color);
		IDataResult<Color> GetColorById(int colorId);
	}
}
