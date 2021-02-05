using Moore_Proccess_Controls.Core.Handler;

namespace Moore_Proccess_Controls.Test.InternalTesting.Handler.CSVFile
{
    public class CSVFileBase : HandlerBase
    {
        internal readonly CSVFileHandler handler;
        public CSVFileBase()
        {
            handler = new CSVFileHandler();
        }
    }
}
