using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class OrderhdService :AbstractService<Orderhd, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateOrdercust(Orderhd OrdercustToValidate)
        {
            return _validationDictionary.IsValid;
        }
    
    }
}
