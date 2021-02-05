using System.Collections.Generic;
using System.IO;
using Moore_Proccess_Controls.Core.Models.Request;

namespace Moore_Proccess_Controls.Core.Validators
{
    public static class LoadCSVFileRequestValidator
    {
        public static bool Validate(this LoadCSVFileRequest request, out List<string> errors)
        {
            errors = new List<string>();
            bool valid = true;
            if (request == default)
            {
                errors.Add("LoadCSVFileRequest must have a value");
                return false;
            }

            if (string.IsNullOrEmpty(request.Path))
            {
                errors.Add("LoadCSVFileRequest path must have a value");
                valid = false;
            }
            else if(!File.Exists(request.Path))
            {
                errors.Add($"Could not find CSV file {request.Path}");
                valid = false;
            }

            return valid;
        }
    }
}
