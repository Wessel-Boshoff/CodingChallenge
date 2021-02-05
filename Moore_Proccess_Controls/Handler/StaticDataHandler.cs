using Moore_Proccess_Controls.Core.Validators;
using Moore_Proccess_Controls.Data.CSV;
using Moore_Proccess_Controls.Core.Models.Request;
using Moore_Proccess_Controls.Core.Models.Response;
using Moore_Proccess_Controls.Core.Models.Enums;
using System.Collections.Generic;
using System;
using Values;
using Moore_Proccess_Controls.Data.DataAccess;

namespace Moore_Proccess_Controls.Core.Handler
{
    public class StaticDataHandler : HandlerBase
    {
        private readonly StaticDataDA da;

        public StaticDataHandler()
        {
            da = new StaticDataDA();
        }
        public GetStaticDataResponse Handle(GetStaticDataRequest request)
        {
            GetStaticDataResponse response = new GetStaticDataResponse();
            try
            {
                if (!request.Validate(out List<string> errors))
                {
                    response.Errors.AddRange(errors);
                    response.ResponseCode = ResponseCodes.Validation;
                    return response;
                }

                switch (request.StaticDataType)
                {
                    case StaticDataType.Tags:
                        GetTags(response);
                        break;
                    case StaticDataType.CalculationTypes:
                        GetCalculationTypes(response);
                        break;
                }

               
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

        private void GetTags(GetStaticDataResponse response) => response.StaticItems = da.GetTags();
        private void GetCalculationTypes(GetStaticDataResponse response) => response.StaticItems = da.GetCalculationTypes();
    }
}
