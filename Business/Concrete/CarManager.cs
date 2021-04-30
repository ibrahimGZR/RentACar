﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }

        }

        public List<Car> GetAll()
        {
            //İş kodlar
            //Yetkisi var mı?

            return _carDal.GetAll();
        }

        public List<Car> GetCarsBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id).ToList();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id).ToList();
        }
    }
}