using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //business codes
            IResult result = BusinessRules.Run(
                CheckIfCarNameExists(car.CarName));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect] //key,value
        public IDataResult<List<Car>> GetAll()
        {
            //İş kodlar
            //Yetkisi var mı?

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == id).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(), Messages.CarDetailsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c=>c.CarId==id));
        }

        [CacheAspect] //key,value
        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.BrandId == id).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.ColorId == id).ToList());
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


        private IResult CheckIfCarNameExists(string carName)
        {
            //aynı isimde ürün ismi varmı
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
