﻿using Moore_Proccess_Controls.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moore_Proccess_Controls.Data.DataAccess
{
    public class CalculationResultDA : BaseDA
    {
        public bool Insert(CalculationResult model) => mooreEntities.InsertCalculationResult(model.Tag.Id, model.CalculationType.Id, model.Value) == 1;
    }
}
