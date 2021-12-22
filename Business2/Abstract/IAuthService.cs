using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
    public interface IAuthService
    {
        IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password);//for user register 
        IDataResult<Users> Login(UserForLoginDto userForLoginDto);//for user login 
        IResults UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Users user);
    }
}
