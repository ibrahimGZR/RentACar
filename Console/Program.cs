using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserAdd();
            //CustomerAdd();

            //CarTest();


            RentalAdd();

        }

        private static void RentalAdd()
        {
            var RentalManager = new RentalManager(new EfRentalDal());
            var result = RentalManager.Add(new Entities.Concrete.Rental
            {
                CarId = 1,
                CustomerId = 2,
                RentDate = DateTime.Now.Date
            });
            Console.WriteLine(result.Message);
        }

        private static void UserAdd()
        {
            var UserManager = new UserManager(new EfUserDal());
            UserManager.Add(new Entities.Concrete.User
            {
                FirstName = "İbrahim",
                LastName = "Gezer",
                Email = "ibrahim@gmail.com",
                Password = "123"
            });
            UserManager.Add(new Entities.Concrete.User
            {
                FirstName = "Salim",
                LastName = "Yanık",
                Email = "salim@gmail.com",
                Password = "1234"
            });
            UserManager.Add(new Entities.Concrete.User
            {
                FirstName = "Fatma",
                LastName = "Üzer",
                Email = "fatnma@gmail.com",
                Password = "12345"
            });
        }

        private static void CustomerAdd()
        {
            var CustomerManager = new CustomerManager(new EfCustomerDal());
            CustomerManager.Add(new Entities.Concrete.Customer
            {
                UserId = 1,
                CompanyName = "Gezer Ltd. Şti."
            });
            CustomerManager.Add(new Entities.Concrete.Customer
            {
                UserId = 2
            });
            CustomerManager.Add(new Entities.Concrete.Customer
            {
                UserId = 3
            });
        }

        private static void CarTest()
        {
            var carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Id:" + car.CarId + "  Yıl:" + car.ModelYear + "  Brand Name:" + car.BrandName + "  Color Name:" + car.ColorName + "  Daily Price:" + car.DailyPrice + "  Açıklama:" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
