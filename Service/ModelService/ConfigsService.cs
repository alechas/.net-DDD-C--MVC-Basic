using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Session.Classes;
using PHD.Service.Abstract;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class ConfigsService : AbstractService<Configs, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateAddress(Configs AddressToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
