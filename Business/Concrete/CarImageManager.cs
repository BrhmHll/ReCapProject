using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		ICarService _carService;

		private string logoPath = @"\images\logo\logo.jpg";

		public CarImageManager(ICarImageDal carImageDal, ICarService carService)
		{
			_carImageDal = carImageDal;
			_carService = carService;
		}

		[SecuredOperation("admin,personel")]
		public IResult AddImageLink(CarImage carImage)
		{
			var countOfImage = _carImageDal.GetAll(i => i.CarId == carImage.CarId).Count();
			if (countOfImage > 4)
			{
				return new ErrorResult(Messages.ImageCountAlert);
			}

			var carIsExists = _carService.GetById(carImage.CarId);
			if (!carIsExists.Success)
			{
				return new ErrorResult(Messages.CarNotFound);
			}
			carImage.Date = DateTime.Now;
			_carImageDal.Add(carImage);
			return new SuccessResult(Messages.Successful);
		}

		[SecuredOperation("admin,personel")]
		public IResult UpdateImageLink(CarImage carImage)
		{
			var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
			if (isImage == null)
			{
				return new ErrorResult(Messages.InvalidValue);
			}

			isImage.Date = DateTime.Now;
			isImage.ImagePath = carImage.ImagePath;
			_carImageDal.Update(carImage);
			return new SuccessResult(Messages.Successful);
		}

		[SecuredOperation("admin,personel")]
		public IResult DeleteImageLink(CarImage carImage)
		{
			var image = _carImageDal.Get(c => c.Id == carImage.Id);
			if (image == null)
			{
				return new ErrorResult(Messages.InvalidValue);
			}

			_carImageDal.Delete(carImage);
			return new SuccessResult(Messages.Successful);
		}

		[SecuredOperation("admin,personel")]
		public IResult AddImage(IFormFile file, CarImage carImage)
		{
			var countOfImage = _carImageDal.GetAll(i => i.CarId == carImage.CarId).Count();
			if (countOfImage > 4)
			{
				return new ErrorResult(Messages.ImageCountAlert);
			}

			var carIsExists = _carService.GetById(carImage.CarId);
			if (!carIsExists.Success)
			{
				return new ErrorResult(Messages.CarNotFound);
			}

			var imageResult = FileHelper.Upload(file);
			if (!imageResult.Success)
			{
				return new ErrorResult(imageResult.Message);
			}

			carImage.ImagePath = imageResult.Message;
			carImage.Date = DateTime.Now;
			carImage.Id = default;
			_carImageDal.Add(carImage);
			return new SuccessResult(Messages.Successful);
		}
		[SecuredOperation("admin,personel")]
		public IResult DeleteImage(CarImage carImage)
		{
			var image = _carImageDal.Get(c => c.Id == carImage.Id);
			if (image == null)
			{
				return new ErrorResult(Messages.InvalidValue);
			}

			FileHelper.Delete(image.ImagePath);
			_carImageDal.Delete(carImage);
			return new SuccessResult(Messages.Successful);
		}
		[SecuredOperation("admin,personel")]
		public IDataResult<CarImage> Get(int id)
		{
			var image = _carImageDal.Get(i => i.Id == id);
			if (image == null)
			{
				return new ErrorDataResult<CarImage>(Messages.InvalidValue);
			}
			return new SuccessDataResult<CarImage>();
		}
		[SecuredOperation("admin,personel")]
		public IDataResult<List<CarImage>> GetAllImagesByCarId(int carId)
		{
			var images = _carImageDal.GetAll(i => i.CarId == carId);
			if (images.Count == 0)
			{
				var carIsExists = _carService.GetById(carId);
				if (!carIsExists.Success)
				{
					return new ErrorDataResult<List<CarImage>>(Messages.CarNotFound);
				}
				CarImage carImage = new CarImage();
				carImage.CarId = carId;
				carImage.Date = DateTime.Now;
				carImage.ImagePath = logoPath;
				return new SuccessDataResult<List<CarImage>>(new List<CarImage> { carImage });
			}
			return new SuccessDataResult<List<CarImage>>(images);

		}
		[SecuredOperation("admin,personel")]
		public IDataResult<CarImage> GetImageByCarId(int carId)
		{
			var result = GetAllImagesByCarId(carId);
			if (!result.Success)
			{
				return new ErrorDataResult<CarImage>(result.Message);
			}
			return new SuccessDataResult<CarImage>(result.Data[0]);
		}

		[SecuredOperation("admin,personel")]
		public IResult UpdateImage(IFormFile file, CarImage carImage)
		{
			var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
			if (isImage == null)
			{
				return new ErrorResult(Messages.InvalidValue);
			}

			var updatedFile = FileHelper.Update(file, isImage.ImagePath);
			if (!updatedFile.Success)
			{
				return new ErrorResult(updatedFile.Message);
			}
			carImage.ImagePath = updatedFile.Message;

			carImage.Date = DateTime.Now;

			_carImageDal.Update(carImage);
			return new SuccessResult(Messages.Successful);
		}

	}
}
