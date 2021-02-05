using System.Collections.Generic;
using System.IO;
using Moore_Proccess_Controls.Core.Models.Request;
using Moore_Proccess_Controls.Core.Models.Enums;

namespace Moore_Proccess_Controls.Core.Validators
{
    public static class InsertCalculationResultRequestValidator
    {
        public static bool Validate(this InsertCalculationResultRequest request, out List<string> errors)
        {
            errors = new List<string>();
            bool valid = true;
            if (request == default)
            {
                errors.Add("InsertCalculationResultRequest must have a value");
                return false;
            }

            if (!request.CalculationResult.CalculationType.Validate(out List<string> errorsCalculationType))
            {
                errors.AddRange(errorsCalculationType);
                valid = false;
            }

            if (!request.CalculationResult.Tag.Validate(out List<string> errorsTag))
            {
                errors.AddRange(errorsTag);
                valid = false;
            }

            if (request.Endpoint == DataEndpoint.None)
            {
                errors.Add("Endpoint is required");
                valid = false;
            }


            return valid;
        }
    }
}
