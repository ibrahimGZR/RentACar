using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarByBranIddAndColorId(int brandId, int colorId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IDataResult<List<CarDetailDto>> GetCarsDetailsById(int id);


    }
}
