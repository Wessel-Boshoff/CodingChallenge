using DataAccess;
using Moore_Proccess_Controls.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Moore_Proccess_Controls.Data.DataAccess.Mapper
{
    internal static class CalculationTypeMapper
    {
        internal static IEnumerable<StaticItem> Map(this IEnumerable<SelectCalculationType_Result> model) => model == default ? new List<StaticItem>() : model.Select(c => c.Map());

        internal static StaticItem Map(this SelectCalculationType_Result model) => model == default ? new StaticItem() : new StaticItem()
        {
            Id = model.Id,
            Value = model.Name
        };
    }
}
