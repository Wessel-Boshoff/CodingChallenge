using DataAccess;
using Moore_Proccess_Controls.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Data.DataAccess.Mapper
{
    internal static class TagMapper
    {
        internal static IEnumerable<StaticItem> Map(this IEnumerable<SelectTag_Result> model) => model == default ? new List<StaticItem>() : model.Select(c => c.Map());

        internal static StaticItem Map(this SelectTag_Result model) => model == default ? new StaticItem() : new StaticItem()
        {
            Id = model.Id,
            Value = model.Name
        };
    }
}
