using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class OrderdtService : AbstractService<Orderdt, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateOrdercust(Orderdt OrdercustToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
