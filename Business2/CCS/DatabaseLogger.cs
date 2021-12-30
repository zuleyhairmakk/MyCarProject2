using System;

namespace Business2.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("veritabanina loglandi");
        }
    }
}
