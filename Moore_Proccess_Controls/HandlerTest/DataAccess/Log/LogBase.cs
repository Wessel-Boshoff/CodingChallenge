using Moore_Proccess_Controls.Data.DataAccess;

namespace Moore_Proccess_Controls.Test.InternalTesting.DataAccess.Log
{
    public class LogBase : DataAccessBase
    {
        protected readonly LogDA da;
        public LogBase()
        {
            da = new LogDA();
        }
    }
}
