using DataAccess;
using Moore_Proccess_Controls.Core.Models;

namespace Moore_Proccess_Controls.Data.DataAccess
{
    public class LogDA : BaseDA
    {
        public bool Insert(Log model) => mooreEntities.InsertLog((int)model.LogLevel, model.Message) == 1;
    }
}
