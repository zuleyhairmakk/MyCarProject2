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

namespace Business2.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(Users user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(Users user)
        {
            _userDal.Add(user);
        }

        public Users GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
