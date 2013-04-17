using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class ReedemService : AbstractService<Reedem, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateReedem(Reedem ReedemToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
