using Business2.Abstract;
using Business2.Constans;
using Business2.ValidationRules;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResults Add(Users user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<Users>> GetAll()
        {
           return new SuccessDataResult<List<Users>>(_userDal.GetAll(),Messages.UserListed);
        }

        public IDataResult<List<Users>> GetByFirstName(string name)
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(p=>p.FirstName== name));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>();
        }
    }
}
