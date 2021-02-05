using Moore_Proccess_Controls.Core.Models.Enums;

namespace Moore_Proccess_Controls.Core.Models
{
    public class Log
    {
        public string Message { get; set; } = "";
        public LogLevels LogLevel { get; set; } = LogLevels.None;
    }
}
