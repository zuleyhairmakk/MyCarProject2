using Business2.Abstract;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Concrete
{
    public class CreditCardManager : ICreditCardService
    {

        ICreditCardDal _creditCardDal;


        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResults Add(CreditCard creditCard)
        {
            var result = BusinessRules.Run(CheckCardIsExists(creditCard.CustomerId, creditCard.CardNo));

            if (result != null)
            {
                return result;
            }

            _creditCardDal.Add(creditCard);

            return new SuccessResult(Messages.CardAdded);
        }


        //[SecuredOperation("admin")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResults Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);

            return new SuccessResult(Messages.CardDeleted);
        }
        //[CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId));
        }


        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResults Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);

            return new SuccessResult(Messages.CardUpdated);
        }


        // Business Rules Methods
        private IResults CheckCardIsExists(int customerId, string cardNo)
        {
            var result = _creditCardDal.Get(c => c.CardNo == cardNo
                                            && c.CustomerId == customerId);

            if (result != null)
            {
                return new ErrorResult(Messages.CardIsExists);
            }
            return new SuccessResult();
        }
    }
}
