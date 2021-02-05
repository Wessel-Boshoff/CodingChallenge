using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moore_Proccess_Controls.Core.Models;
using Moore_Proccess_Controls.Core.Models.Enums;

namespace Moore_Proccess_Controls.Core.Models.Request
{
    public class LogRequest
    {
        public Log Log { get; set; }

        public LogRequest()
        { }

        public LogRequest(LogLevels level, string message)
        {
            Log = new Log()
            {
                LogLevel = level,
                Message = message
            };
        }
    }
}
