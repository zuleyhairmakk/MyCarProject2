using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business2.Constans
{
   public static  class Messages
    {
        public static string CarAdded = "araba eklendi";
        public static string CarNameInvalid = "araba ismi gecersiz";
        public static string MaintenanceTime = "sistem bakimda ";
        public static string CarListed = "arabalar listelendi ";
        public static string CustomerListed = "musteriler listelendi ";
        public static string CustomerAdded = "musteriler eklendi";
        public static string UserListed = "kullanicilar listelendi ";
        public static string UserAdded= "kullanici eklendi ";
        public static string ColorListed = "renk listelendi ";
        public static string ColorAdded = "renk eklendi ";
        public static string BrandListed = "markalar listelendi ";
        internal static string CarImagesListed;
        internal static string CarImageLimitExceeded;

        public static string AuthorizationDenied = "";
    }
}
