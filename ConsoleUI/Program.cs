using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());

			Car car1 = new Car();
			car1.Id = 2;
			car1.ModelYear = 1021;
			car1.BrandId = 2;
			car1.ColorId = 2;
			car1.DailyPrice = 300;
			car1.Description = "Super Car";

			carManager.AddNewCar(car1);

			List<Car> cars = carManager.GetAll();

			foreach (var c in cars)
			{
				Console.WriteLine(c.Description);
			}
		}
	}
}
    