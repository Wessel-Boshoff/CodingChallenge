using Moore_Proccess_Controls.Core.Models;
using Moore_Proccess_Controls.Core.Models.Enums;
using Moore_Proccess_Controls.Data.DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Data.DataAccess
{
    public class StaticDataDA : BaseDA
    {
        private static readonly Dictionary<StaticDataType, List<StaticItem>> valueCache = new Dictionary<StaticDataType, List<StaticItem>>();

        public List<StaticItem> GetTags()
        {
            List<StaticItem> staticItems;
            if (!valueCache.ContainsKey(StaticDataType.Tags))
            {
                staticItems = mooreEntities.SelectTag()?.Map().ToList() ?? new List<StaticItem>();
                valueCache.Add(StaticDataType.Tags, staticItems);
            }
            else
            {
                staticItems = valueCache[StaticDataType.Tags];
            }

            return staticItems;
        }

        public List<StaticItem> GetCalculationTypes()
        {
            List<StaticItem> staticItems;
            if (!valueCache.ContainsKey(StaticDataType.CalculationTypes))
            {
                staticItems = mooreEntities.SelectCalculationType()?.Map().ToList() ?? new List<StaticItem>();
                valueCache.Add(StaticDataType.CalculationTypes, staticItems);
            }
            else
            {
                staticItems = valueCache[StaticDataType.CalculationTypes];
            }

            return staticItems;
        }

    }
}
