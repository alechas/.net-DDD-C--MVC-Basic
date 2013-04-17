using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class UpgradeService : AbstractService<Upgrade, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateUpgrade(Upgrade UpgradeToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
