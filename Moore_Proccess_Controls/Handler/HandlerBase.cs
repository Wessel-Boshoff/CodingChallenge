using Moore_Proccess_Controls.Core.Models.Enums;
using Moore_Proccess_Controls.Data.DataAccess;
using Moore_Proccess_Controls.Core.Models;

namespace Moore_Proccess_Controls.Core.Handler
{
    public class HandlerBase
    {
        protected LogDA logDA;
        public HandlerBase()
        {
            logDA = new LogDA();
        }

        protected bool Log(LogLevels level, string message) => logDA.Insert(new Log() { LogLevel = level, Message = message});
    }
}
