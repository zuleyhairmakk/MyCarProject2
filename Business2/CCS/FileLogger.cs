using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.CCS
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("dosyaya loglandi");
        }
    }
}
