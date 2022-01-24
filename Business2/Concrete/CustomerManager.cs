using Business2.Abstract;
using Business2.BusinessAspects.Autofac;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResults Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResults Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccessResult(Messages.CustomerDeleted);
        }


         [CacheAspect]
        [CacheRemoveAspect("ICustomerService.Get")]
        [PerformanceAspect(10)]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.MessageListed);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<UserWhoIsCustomerDto> GetByEmail(string email)
        {
            return new SuccessDataResult<UserWhoIsCustomerDto>(_customerDal.GetCustomerIdOfUser(email));
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>();
        }



       [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResults Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}

    
