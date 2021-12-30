using Business2.Abstract;
using Business2.BusinessAspects.Autofac;
using Business2.Constans;
using Business2.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business2.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;


        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


       // [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserValidator))]
     
        public IResults Add(Users user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }


       [SecuredOperation("admin")]
       
        public IResults Delete(Users user)
        {
            _userDal.Delete(user);

            return new SuccessResult(Messages.UserDeleted);
        }


        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(UserValidator))]
      
        public IResults Update(Users user)
        {
            _userDal.Update(user);

            return new SuccessResult(Messages.UserUpdated);
        }


        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(UserValidator))]

       [CacheRemoveAspect("IUserService.Get")]
        public IResults UpdateSpecificInfos(Users user)
        {
            Users userInfos = GetById(user.Id).Data;

            userInfos.FirstName = user.FirstName;
            userInfos.LastName = user.LastName;
            userInfos.Email = user.Email;

            _userDal.Update(userInfos);

            return new SuccessResult(Messages.UserUpdated);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Users>> GetAll()
        {
           // if (DateTime.Now.Hour == 22)
           // {
              //  return new ErrorDataResult<List<Users>>(Messages.MaintenanceTime);
           //}
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(), Messages.MessageListed);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Users> GetById(int userId)
        {
            return new SuccessDataResult<Users>(_userDal.Get(u => u.Id == userId));
        }


        public IDataResult<Users> GetByEmail(string email)
        {
            Users user = _userDal.Get(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                return new ErrorDataResult<Users>(Messages.MessageNotListed);
            }
            else
            {
                return new SuccessDataResult<Users>(user, Messages.MessageListed);
            }
        }


        public IDataResult<List<OperationClaim>> GetClaims(Users user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

    }
}
