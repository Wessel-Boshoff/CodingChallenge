using System.Collections.Generic;

namespace Moore_Proccess_Controls.Core.Models.Response
{
    public class GetStaticDataResponse : BaseResponse
    {
        public List<StaticItem> StaticItems { get; set; } = new List<StaticItem>();
    }
}
