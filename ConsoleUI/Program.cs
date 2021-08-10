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
			// 4.5.2021 - 1.50 A.M. All function tested.

			//Car
			CarManager carManager = new CarManager(new EfCarDal());
			//AddNewCarTest(carManager);
			//GetAllCarTest(carManager);
			//GetCarDetailTest(carManager);
			//GetCarByIdTest(carManager);
			//GetCarDetailByIdTest(carManager);	
			//GetCarsByBrandIdTest(carManager);
			//GetCarsByColorIdTest(carManager);

			//Color
			ColorManager colorManager = new ColorManager(new EfColorDal());
			//AddNewColorTest(colorManager);
			//GetAllColorTest(colorManager);

			//Brand
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			//AddNewBrandTest(brandManager);
			//GetAllBrandTest(brandManager);

			//Rental
			//RentalManager rentalManager = new RentalManager(new EfRentalDal(), new EfCarDal());
			//RentalTest(rentalManager);
			//GetAllRental(rentalManager);
			//GetRentalByIdTest(rentalManager);
			//GetRentalDetailsById(rentalManager);
			//GetAllRentalDetails(rentalManager);

			//Customer
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
			//AddNewCustomerTest(customerManager);
			//UpdateCustomerTest(customerManager);
			//GetAllCustomerTest(customerManager);
			//RemoveCustomerTest(customerManager);

			//User
			UserManager2 userManager = new UserManager2(new EfUserDal());
			//AddNewUserTest(userManager);
			//GetAllUserTest(userManager);
			//UpdateUserTest(userManager);
			//RemoveUserTest(userManager);
		}

		private static void RemoveUserTest(UserManager2 userManager)
		{
			User user = new User();
			user.FirstName = "Engin";
			user.LastName = "Demiroğ";
			user.Email = "engindemirog0@gmail.com";
			user.Password = "enginhoca";
			var result = userManager.RemoveUser(user);
			if (result.Success)
				Console.WriteLine(result.Message);
			else
				Console.WriteLine(result.Message);
		}

		private static void UpdateUserTest(UserManager2 userManager)
		{
			User user = new User();
			user.Email = "ibrahimsakar0@gmail.com";
			user.FirstName = "İbrahim Halil";
			user.LastName = "SAKAR";
			user.Password = "12345678";
			var result = userManager.UpdateUser(user);
			if (result.Success)
				Console.WriteLine(result.Message);
			else
				Console.WriteLine(result.Message);
		}

		private static void UpdateCustomerTest(CustomerManager customerManager)
		{
			Customer customer = new Customer();
			customer.CompanyName = "Hello World Inc.";
			var result = customerManager.UpdateCustomer(customer);
			if (result.Success)
				Console.WriteLine(result.Message);
		}

		private static void RemoveCustomerTest(CustomerManager customerManager)
		{
			Customer customer = new Customer();
			customer.CompanyName = "";
			var result = customerManager.RemoveCustomer(customer);
			if (result.Success)
				Console.WriteLine(result.Message);
		}

		private static void GetAllRentalDetails(RentalManager rentalManager)
		{
			var rentals = rentalManager.GetRentalDetails();
			if (rentals.Success)
			{
				foreach (var rental in rentals.Data)
				{
					Console.WriteLine(rental.CompanyName + " " + rental.RentDate);
				}
			}
			else
				Console.WriteLine(rentals.Message);
		}

		private static void GetRentalDetailsById(RentalManager rentalManager)
		{
			var rental = rentalManager.GetRentalDetailsById(1);
			if (rental.Success)
				Console.WriteLine(rental.Data.CompanyName + " " + rental.Data.RentDate);
			else
				Console.WriteLine(rental.Message);
		}

		private static void GetRentalByIdTest(RentalManager rentalManager)
		{
			var rental = rentalManager.GetById(1);
			if (rental.Success)
				Console.WriteLine(rental.Data.CustomerId + " " + rental.Data.RentDate);
			else
				Console.WriteLine(rental.Message);
		}

		private static void GetCarDetailTest(CarManager carManager)
		{
			var cars = carManager.GetCarDetails();
			if (cars.Success)
			{
				foreach (var c in cars.Data)
				{
					Console.WriteLine(c.BrandName + " " + c.Description);
				}
			}
			else
				Console.WriteLine(cars.Message);
			
		}

		private static void GetCarsByColorIdTest(CarManager carManager)
		{
			var cars = carManager.GetCarsByColorId(1);
			if (cars.Success)
			{
				foreach (var c in cars.Data)
				{
					Console.WriteLine(c.ColorId + " " + c.Description);
				}
			}
			else
				Console.WriteLine(cars.Message);

		}

		private static void GetCarsByBrandIdTest(CarManager carManager)
		{
			var car = carManager.GetCarsByBrandId(1);
			if (car.Success)
			{
				foreach (var c in car.Data)
				{
					Console.WriteLine(c.Description);
				}
			}
			else
				Console.WriteLine(car.Message);
		}

		private static void GetAllUserTest(UserManager2 userManager)
		{
			var users = userManager.GetAll();
			if (users.Success)
			{
				foreach (var user in users.Data)
				{
					Console.WriteLine(user.FirstName + " " + user.LastName);
				}
			}
			else
				Console.WriteLine(users.Message);
		}

		private static void AddNewUserTest(UserManager2 userManager)
		{
			User user1 = new User();
			user1.FirstName = "Engin";
			user1.LastName = "Demiroğ";
			user1.Email = "engindemirog0@gmail.com";
			user1.Password = "enginhoca";
			var result = userManager.AddNewUser(user1);

			if (result.Success == false)
				Console.WriteLine(result.Message);
			else
				Console.WriteLine(result.Message);
		}

		private static void GetAllCustomerTest(CustomerManager customerManager)
		{
			var customers = customerManager.GetAll();
			if (customers.Success)
			{
				foreach (var c in customers.Data)
				{
					Console.WriteLine(c.CompanyName);
				}
			}
			else
				Console.WriteLine(customers.Message);
		}

		public static void AddNewCustomerTest(CustomerManager customerManager)
		{
			Customer customer = new Customer();
			customer.CompanyName = "IHS";

			var result = customerManager.AddNewCustomer(customer);
			if (result.Success == false)
				Console.WriteLine(result.Message);
			else
				Console.WriteLine(result.Message);
		}

		private static void GetAllRental(RentalManager rentalManager)
		{
			var rentals = rentalManager.GetAll();
			if (rentals.Success)
			{
				foreach (var r in rentals.Data)
				{
					Console.WriteLine(r.Id + " " + r.RentDate + " " + r.ReturnDate);
				}
			}
			else
				Console.WriteLine(rentals.Message);
		}

		private static void RentalTest(RentalManager rentalManager)
		{
			Rental rental = new Rental();
			rental.CarId = 2;
			rental.CustomerId = 1;
			rental.RentDate = DateTime.Now;
			rental.ReturnDate = default;

			rentalManager.Rental(rental);
		}

		private static void GetCarDetailByIdTest(CarManager carManager)
		{
			var carDetail = carManager.GetCarDetailsById(1);
			if (carDetail.Success)
				Console.WriteLine(carDetail.Data.CarId + ". " + carDetail.Data.BrandName + " " + carDetail.Data.DailyPrice + " " + carDetail.Data.ColorName);
			else
				Console.WriteLine(carDetail.Message);
		}

		private static void GetCarByIdTest(CarManager carManager)
		{
			var gettedCar = carManager.GetById(2);
			if (gettedCar.Success)
				Console.WriteLine(gettedCar.Data.CarId + " " + gettedCar.Data.Description);
			else
				Console.WriteLine(gettedCar.Message);
		}

		private static void GetAllBrandTest(BrandManager brandManager)
		{
			var brands = brandManager.GetAll();
			if (brands.Success)
			{
				foreach (var brand in brands.Data)
				{
					Console.WriteLine(brand.BrandId + " " + brand.BrandName);
				}
			}
			else
				Console.WriteLine(brands.Message);
		}

		private static void GetAllColorTest(ColorManager colorManager)
		{
			var colors = colorManager.GetAll();
			if (colors.Success)
			{
				foreach (var color in colors.Data)
				{
					Console.WriteLine(color.ColorId + " " + color.ColorName);
				}
			}
			else
				Console.WriteLine(colors.Message);
		}

		private static void GetAllCarTest(CarManager carManager)
		{
			var cars = carManager.GetCarDetails();

			if (cars.Success)
			{
				foreach (var c in cars.Data)
				{
					Console.WriteLine(c.CarId + ". " + c.BrandName + " " + c.DailyPrice + " " + c.ColorName);
				}
			}
			else
				Console.WriteLine(cars.Message);
		}

		private static void AddNewBrandTest(BrandManager brandManager)
		{
			Brand brand1 = new Brand();
			brand1.BrandName = "Hyundai";

			brandManager.AddNewBrand(brand1);
		}

		private static void AddNewColorTest(ColorManager colorManager)
		{
			Color color1 = new Color();
			color1.ColorName = "Kırmızı";

			colorManager.AddNewColor(color1);
		}

		private static void AddNewCarTest(CarManager carManager)
		{
			Car car1 = new Car();
			car1.ModelYear = 1021;
			car1.BrandId = 2;
			car1.ColorId = 2;
			car1.DailyPrice = 300;
			car1.Description = "Super Car";

			carManager.AddNewCar(car1);
		}
	}
}
    