using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class SaranService : AbstractService<Saran, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateSaran(Saran SaranToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
