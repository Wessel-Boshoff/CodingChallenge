using Moore_Proccess_Controls.Core.Models.Enums;
namespace Moore_Proccess_Controls.Core.Models.Request
{
    public class GetStaticDataRequest : BaseRequest
    {
        public StaticDataType StaticDataType { get; set; } = StaticDataType.None;
    }
}
