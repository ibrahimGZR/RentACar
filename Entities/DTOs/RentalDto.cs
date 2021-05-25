using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDto : IDto
    {
        public int Id { get; set; }
        public  CarDetailDto CarDto { get; set; }
        public  CustomerDto CustomerDto { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
