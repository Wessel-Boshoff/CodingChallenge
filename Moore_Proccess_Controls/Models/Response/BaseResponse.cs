using Moore_Proccess_Controls.Core.Models.Enums;
using System.Collections.Generic;

namespace Moore_Proccess_Controls.Core.Models.Response
{
    public class BaseResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ResponseCodes ResponseCode { get; set; } = ResponseCodes.Success;
    }
}
