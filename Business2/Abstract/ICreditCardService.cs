using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
  public   interface ICreditCardService
    {
        IResults Add(CreditCard creditCard);
        IResults Delete(CreditCard creditCard);
        IResults Update(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetByCustomerId(int customerId);
    }
}
