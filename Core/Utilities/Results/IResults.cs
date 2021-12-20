using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResults
    {
        //temel voidler icin baslangic 
        bool Success { get;  }
        public string  Message { get;  }
    }
}
