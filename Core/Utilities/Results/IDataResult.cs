using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  public   interface IDataResult<T>:IResults
    {
        //success ve message haricinde bir de datamiz olacak 
        T Data { get; }
    }
}
