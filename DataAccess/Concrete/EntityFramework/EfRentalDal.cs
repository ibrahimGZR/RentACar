using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDto> GetRantalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join ca in context.Cars
                             on r.CarId equals ca.CarId
                             join u in context.Users
                             on c.UserId equals u.UserId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             select new RentalDto
                             {
                                 Id = r.Id,
                                 CustomerDto =
                                 {
                                     CustomerId=c.CustomerId,
                                     FirstName=u.FirstName,
                                     LastName=u.LastName,
                                     Email=u.Email,
                                     CompanyName=c.CompanyName
                                 },
                                 CarDto =
                                 {
                                     CarId=ca.CarId,
                                     BrandName=b.BrandName,
                                     ColorName=co.ColorName,
                                     ModelYear=ca.ModelYear,
                                     DailyPrice=ca.DailyPrice,
                                     Description=ca.Description
                                 },
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
