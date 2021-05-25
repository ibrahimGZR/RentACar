using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetById(int id);
        IDataResult<List<Rental>> GetRentalsByCarId(int id);
        IDataResult<List<Rental>> GetRentalsByCustomerId(int id);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<RentalDto>> GetRentalsDetails();
        IDataResult<List<RentalDto>> GetRentalsDetailsById(int id);
    }
}
