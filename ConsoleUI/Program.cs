using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			// 2.5.2021 - 3.00 A.M. All function tested.
			CarManager carManager = new CarManager(new EfCarDal());
			ColorManager colorManager = new ColorManager(new EfColorDal());
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			Car car1 = new Car();
			car1.CarId = 2;
			car1.ModelYear = 1021;
			car1.BrandId = 2;
			car1.ColorId = 2;
			car1.DailyPrice = 300;
			car1.Description = "Super Car";

			Color color1 = new Color();
			color1.ColorId = 3;
			color1.ColorName = "Kırmızı";

			Brand brand1 = new Brand();
			brand1.BrandId = 3;
			brand1.BrandName = "Hyundai";

			Color color2 = new Color();
			color2.ColorId = 4;
			color2.ColorName = "Mavi";

			Brand brand2 = new Brand();
			brand2.BrandId = 4;
			brand2.BrandName = "Renault";

			//carManager.AddNewCar(car1);
			//colorManager.AddNewColor(color1);
			//colorManager.AddNewColor(color2);
			//brandManager.AddNewBrand(brand1);
			//brandManager.AddNewBrand(brand2);


			List<CarDetailDto> cars = carManager.GetCarDetails();

			foreach (var c in cars)
			{
				Console.WriteLine(c.CarId +". "+ c.BrandName+" "+c.DailyPrice+" "+c.ColorName);
			}

			List<Color> colors = colorManager.GetAll();
			foreach (var color in colors)
			{
				Console.WriteLine(color.ColorId +" "+ color.ColorName);
			}

			List<Brand> brands = brandManager.GetAll();
			foreach (var brand in brands)
			{
				Console.WriteLine(brand.BrandId + " " + brand.BrandName);
			}

			Car gettedCar = carManager.GetById(1);
			Console.WriteLine(gettedCar.CarId +" "+ gettedCar.Description);

			CarDetailDto carDetail = carManager.GetCarDetailsById(1);
			Console.WriteLine(carDetail.CarId + ". " + carDetail.BrandName + " " + carDetail.DailyPrice + " " + carDetail.ColorName);
		}
	}
}
    