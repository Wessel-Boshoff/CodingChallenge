using Moore_Proccess_Controls.Core.Models.Enums;
using Moore_Proccess_Controls.Core.Models.Request;
using Moore_Proccess_Controls.Core.Models.Response;
using Moore_Proccess_Controls.Core.Validators;
using Moore_Proccess_Controls.Core.Values;
using Moore_Proccess_Controls.Data.CSV;
using Moore_Proccess_Controls.Data.DataAccess;
using System;
using System.Collections.Generic;
using Values;

namespace Moore_Proccess_Controls.Core.Handler
{
    public class CalculationResultHandler : HandlerBase
    {
        private readonly CalculationResultDA da;

        public CalculationResultHandler()
        {
            da = new CalculationResultDA();
        }
        public InsertCalculationResultResponse Insert(InsertCalculationResultRequest request)
        {
            InsertCalculationResultResponse response = new InsertCalculationResultResponse();
            try
            {
                if (!request.Validate(out List<string> errors))
                {
                    response.Errors.AddRange(errors);
                    response.ResponseCode = ResponseCodes.Validation;
                    return response;
                }

                switch (request.Endpoint)
                {
                    case DataEndpoint.DB:
                        InsertDB(response, request);
                        break;
                    case DataEndpoint.CSV:
                        InsertCSV(response, request);
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

        private void InsertDB(InsertCalculationResultResponse response,InsertCalculationResultRequest request) => 
            response.ResponseCode = da.Insert(request.CalculationResult) ? ResponseCodes.Success : ResponseCodes.Error;

        private void InsertCSV(InsertCalculationResultResponse response, InsertCalculationResultRequest request) =>
            response.ResponseCode = Saving.Save(new List<string>() 
            { 
                "Calculation Type",
                "TAG", 
                "Value" 
            }, 
                new List<List<string>>() { new List<string> 
                { 
                    request.CalculationResult.CalculationType.Value.ToString(), 
                    request.CalculationResult.Tag.Value.ToString(),
                    string.Join(' '.ToString(), request.CalculationResult.Value) 
                } 
            }) ? ResponseCodes.Success : ResponseCodes.Error;
    }
}
