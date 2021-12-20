using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
   public  interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResults Add(Customer customer);
        IDataResult<List<Customer>> GetByCustomerId(int id);
    }
}
