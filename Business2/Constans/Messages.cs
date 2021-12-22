using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business2.Constans
{
   public static  class Messages
    {
        public static string CarAdded = "CarAdded ";
        public static string CarNameInvalid = "CarNameInvalid";
        public static string MaintenanceTime = "MaintenanceTime  ";
        public static string CarListed = "CarListed  ";
        public static string CustomerListed = "CustomerListed ";
        public static string CustomerAdded = "CustomerAdded";
        public static string UserListed = "UserListed  ";
        public static string UserAdded= "ColorAdded";
        public static string ColorListed = "renk listelendi ";
        public static string ColorAdded = "ColorAdded ";
        public static string BrandListed = "BrandListed ";
        internal static string CarImagesListed;
        internal static string CarImageLimitExceeded;

        public static string AuthorizationDenied = "AuthorizationDenied";
     public static string UserRegistered= "UserRegistered ";
        public static string  UserNotFound= "UserNotFound";
       public static string PasswordError="password error  ";
      public static string SuccessfulLogin="successfull login  ";
       public static string UserAlreadyExists="user already exists";
        public static string AccessTokenCreated= "AccessTokenCreated;";
    }
}
