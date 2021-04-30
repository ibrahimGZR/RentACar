using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand {BrandName = "BMW" });
            //brandManager.Add(new Brand {BrandName = "Jeep" });

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color {ColorName = "Beyaz" });
            //colorManager.Add(new Color {ColorName = "Siyah" });

            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car {BrandId = 1, ColorId = 1, ModelYear = 1998, DailyPrice = 50000, Description = "Araç manuel vites" });
            //carManager.Add(new Car {BrandId = 1, ColorId = 1, ModelYear = 2002, DailyPrice = 95000, Description = "Araç manuel vites" });
            //carManager.Add(new Car {BrandId = 2, ColorId = 2, ModelYear = 2008, DailyPrice = 150000, Description = "Araç manuel vites" });
            //carManager.Add(new Car {BrandId = 2, ColorId = 2, ModelYear = 2015, DailyPrice = 250000, Description = "Araç otomatik vites" });
            //carManager.Add(new Car {BrandId = 2, ColorId = 2, ModelYear = 2020, DailyPrice = 500000, Description = "Araç otomatik vites" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Id:" + car.Id + " Car Name:" + car.CarName + " Yıl:" + car.ModelYear + " Brand Id:" + car.BrandId + " Color Id:" + car.ColorId + " Daily Price:" + car.DailyPrice + " Açıklama:" + car.Description);
            }


        }
    }
}
