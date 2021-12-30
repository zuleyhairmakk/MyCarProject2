using Business2.Abstract;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;


        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        [ValidationAspect(typeof(PaymentValidator))]
        public IResults Add(Payment payment)
        {
            _paymentDal.Add(payment);

            return new SuccessResult(Messages.PaymentAdded);
        }
    }
}
