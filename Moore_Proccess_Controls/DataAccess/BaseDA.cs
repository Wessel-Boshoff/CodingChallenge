using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Moore_Proccess_Controls.Data.DataAccess
{
    public class BaseDA
    {
        protected readonly Moore_Proccess_ControlsEntities mooreEntities;
        public BaseDA()
        {
            mooreEntities = new Moore_Proccess_ControlsEntities();
        }
    }
}
