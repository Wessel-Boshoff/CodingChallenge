using Moore_Proccess_Controls.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Core.Models.Request
{
    public class InsertCalculationResultRequest : BaseRequest
    {
        public CalculationResult CalculationResult { get; set; } = new CalculationResult();
        public DataEndpoint Endpoint { get; set; } = DataEndpoint.None;
    }
}
