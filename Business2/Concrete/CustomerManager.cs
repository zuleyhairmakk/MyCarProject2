using Business2.Abstract;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
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
        ICustomerDal _customerrDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerrDal = customerDal;
        }



        [ValidationAspect(typeof(CustomerValidator))]
        public IResults Add(Customer customer)
        {
            _customerrDal.Add(customer);
            
           return  new SuccessResult(Messages.CustomerAdded);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerrDal.GetAll(),Messages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerrDal.GetAll(p=>p.CustomerId==id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>();
        }
    }
}
