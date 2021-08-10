using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		public IResult AddImage(IFormFile file, CarImage carImage);
		public IResult UpdateImage(IFormFile file, CarImage carImage);
		public IResult DeleteImage(CarImage carImage);
		public IResult AddImageLink(CarImage carImage);
		public IResult UpdateImageLink(CarImage carImage);
		public IResult DeleteImageLink(CarImage carImage);
		public IDataResult<List<CarImage>> GetAllImagesByCarId(int carId);
		public IDataResult<CarImage> GetImageByCarId(int carId);
		public IDataResult<CarImage> Get(int id);

	}
}
