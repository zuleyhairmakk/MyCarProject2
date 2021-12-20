
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
  public   class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public int CustomerId { get; set; }
       
    }
}
