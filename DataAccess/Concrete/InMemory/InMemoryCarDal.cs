using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId=1, BrandId=1, ColorId=1, ModelYear=1998, DailyPrice=50000, Description="Araç manuel vites"},
                 new Car{ CarId=2, BrandId=1, ColorId=1, ModelYear=2002, DailyPrice=95000, Description="Araç manuel vites"},
                  new Car{ CarId=3, BrandId=2, ColorId=2, ModelYear=2008, DailyPrice=150000, Description="Araç manuel vites"},
                   new Car{ CarId=4, BrandId=2, ColorId=2, ModelYear=2015, DailyPrice=250000, Description="Araç otomatik vites"},
                    new Car{ CarId=5, BrandId=2, ColorId=2, ModelYear=2020, DailyPrice=500000, Description="Araç otomatik vites"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars
                .SingleOrDefault(p => p.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars
                 .SingleOrDefault(p => p.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
