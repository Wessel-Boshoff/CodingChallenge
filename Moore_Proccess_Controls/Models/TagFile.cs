using System.Collections.Generic;

namespace Moore_Proccess_Controls.Core.Models
{
    public class TagFile
    {
        public List<string> Headers { get; set; } = new List<string>();
        public List<TagLine> Lines { get; set; } = new List<TagLine>();
    }
}
