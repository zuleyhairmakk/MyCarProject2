using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResults
    {
        

        public Result(bool success, string message):this(success)
        {
            Message = message;
            //Success = success;//do not rep.
        }
        public Result(bool success)
        {
        
                Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
