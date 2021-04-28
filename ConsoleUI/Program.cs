using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new InMemoryCarDal());
			List<Car> cars = carManager.GetAll();

			foreach (var c in cars)
			{
				Console.WriteLine(c.Description);
			}
		}
	}
}
