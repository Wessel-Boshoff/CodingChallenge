using Moore_Proccess_Controls.Core.Models;
using Moore_Proccess_Controls.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Mapper
{
    public static class TagLineMapper
    {
        public static List<TagLineModel> Map(this List<TagLine> model) => model == default ? new List<TagLineModel>() : model.Select(c => c.Map()).ToList();

        public static TagLineModel Map(this TagLine model)
        {
            if (model == default)
            {
                return new TagLineModel();
            }
            TagLineModel modelMapped = new TagLineModel();
            try
            {
                modelMapped.GetType().GetProperty("TS").SetValue(modelMapped, model.TS);
                var ss = model.Tags.Select(c => c);
                string json = JsonConvert.SerializeObject(model);
                for (int i = 1; i < 18; i++)
                {
                    modelMapped.GetType().GetProperty(string.Format("TAG{0}", i)).SetValue(modelMapped, model.Tags.Skip(i - 1).First());
                }
            }
            catch (Exception ex)
            {
                //TODO add error handling here
            }
            return modelMapped;
        }
    }
}
