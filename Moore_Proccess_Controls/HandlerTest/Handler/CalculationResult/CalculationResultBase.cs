using Moore_Proccess_Controls.Core.Handler;

namespace Moore_Proccess_Controls.Test.InternalTesting.Handler.CalculationResult
{
    public class CalculationResultBase : HandlerBase
    {
        internal readonly CalculationResultHandler handler;
        public CalculationResultBase()
        {
            handler = new CalculationResultHandler();
        }
    }
}
