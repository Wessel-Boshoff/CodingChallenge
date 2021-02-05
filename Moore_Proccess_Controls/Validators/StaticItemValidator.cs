using Moore_Proccess_Controls.Core.Models;
using System.Collections.Generic;
using System.IO;

namespace Moore_Proccess_Controls.Core.Validators
{
    public static class StaticItemValidator
    {
        public static bool Validate(this StaticItem model, out List<string> errors)
        {
            errors = new List<string>();
            bool valid = true;
            if (model == default)
            {
                errors.Add("StaticItem must have a value");
                return false;
            }

            if (model.Id == default)
            {
                errors.Add("Item must have an Id");
                valid = false;
            }


            return valid;
        }
    }
}
