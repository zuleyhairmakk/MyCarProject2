using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
 public   interface IPaymentService
    {
        IResults Add(Payment payment);
    }
}
