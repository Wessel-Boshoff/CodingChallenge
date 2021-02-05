using Moore_Proccess_Controls.Core.Models;

namespace Moore_Proccess_Controls.Core.Models.Response
{
    public class LoadCSVFileResponse : BaseResponse
    {
        public TagFile FileData { get; set; } = new TagFile();
    }
}
