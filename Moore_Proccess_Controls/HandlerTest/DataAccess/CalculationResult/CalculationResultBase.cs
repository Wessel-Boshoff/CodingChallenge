using Moore_Proccess_Controls.Data.DataAccess;

namespace Moore_Proccess_Controls.Test.InternalTesting.DataAccess.CalculationResult
{
    public class CalculationResultBase : DataAccessBase
    {
        protected readonly CalculationResultDA da;
        public CalculationResultBase()
        {
            da = new CalculationResultDA();
        }
    }
}
