using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class EmptymenuService : AbstractService<Emptymenu, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateEmptymenu(Emptymenu EmptymenuToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
