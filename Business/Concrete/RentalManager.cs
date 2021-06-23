using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var results = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var result in results)
            {
                if (result.ReturnDate == Convert.ToDateTime("1.01.0001"))
                {
                    return new ErrorResult(Messages.RentalCarNotReturn);
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.Id==id).ToList());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetailsByCarId(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetails(r => r.CarDto.CarId == id).ToList());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetailsByCustomerId(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetails(r => r.CustomerDto.CustomerId == id).ToList());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetailsById(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetails(r=>r.Id==id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
