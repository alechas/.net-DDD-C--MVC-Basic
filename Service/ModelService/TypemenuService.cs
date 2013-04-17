using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class TypemenuService : AbstractService<Typemenu, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateTypemenu(Typemenu TypemenuToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
