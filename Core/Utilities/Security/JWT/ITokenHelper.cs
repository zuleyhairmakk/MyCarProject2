using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public  interface ITokenHelper
    {
        //token uretecek mekanizma 
        AccessToken CreateToken(Users user, List<OperationClaim> operationClaims)
    }
}
