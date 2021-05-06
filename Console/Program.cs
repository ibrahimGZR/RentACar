using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var carManager = new CarManager(new EfCarDal());
            //carManager.Update(new Entities.Concrete.Car
            //{
            //    CarId=17,
            //    BrandId = 6,
            //    ColorId = 6,it
            //    ModelYear = 1111,
            //    DailyPrice = 1111111,
            //    Description = "deneme2"
            //});

            CarTest();



        }

        private static void CarTest()
        {
            var carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Id:" + car.CarId + "  Yıl:" + car.ModelYear + "  Brand Name:" + car.BrandName + "  Color Name:" + car.ColorName + "  Daily Price:" + car.DailyPrice + "  Açıklama:" + car.Description);
            }
        }
    }
}
