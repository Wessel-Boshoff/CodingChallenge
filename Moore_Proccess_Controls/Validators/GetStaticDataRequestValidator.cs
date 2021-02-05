using System.Collections.Generic;
using System.IO;
using Moore_Proccess_Controls.Core.Models.Request;

namespace Moore_Proccess_Controls.Core.Validators
{
    public static class GetStaticDataRequestValidator
    {
        public static bool Validate(this GetStaticDataRequest request, out List<string> errors)
        {
            errors = new List<string>();
            bool valid = true;
            if (request == default)
            {
                errors.Add("GetStaticDataRequest must have a value");
                return false;
            }

            if (request.StaticDataType == Models.Enums.StaticDataType.None)
            {
                errors.Add("StaticDataType is required");
                valid = false;
            }

            return valid;
        }
    }
}
