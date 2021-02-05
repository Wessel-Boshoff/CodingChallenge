using Moore_Proccess_Controls.Core.Validators;
using Moore_Proccess_Controls.Data.CSV;
using Moore_Proccess_Controls.Core.Models.Request;
using Moore_Proccess_Controls.Core.Models.Response;
using Moore_Proccess_Controls.Core.Models.Enums;
using System.Collections.Generic;
using System;
using Values;

namespace Moore_Proccess_Controls.Core.Handler
{
    public class CSVFileHandler : HandlerBase
    {
        public LoadCSVFileResponse Load(LoadCSVFileRequest request)
        {
            LoadCSVFileResponse response = new LoadCSVFileResponse();
            try
            {
                if (!request.Validate(out List<string> errors))
                {
                    response.Errors.AddRange(errors);
                    response.ResponseCode = ResponseCodes.Validation;
                    return response;
                }

                response.FileData = Loader.LoadFile(request.Path);
                return response;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ErrorMessages.GenericError);
                response.ResponseCode = ResponseCodes.Error;
                Log(LogLevels.Error, ex.ToString());
                return response;
            }
        }
    }
}
