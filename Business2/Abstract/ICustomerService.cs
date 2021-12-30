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

        IResults Add(Customer customer);
        IResults Delete(Customer customer);
        IResults Update(Customer customer);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);
      //  IDataResult<UserWhoIsCustomerDto> GetByEmail(string email);
    }
}
;