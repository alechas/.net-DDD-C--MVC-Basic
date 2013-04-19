using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Abstract;
using Session.Classes;
using Service.Validation;
using System.Web.Mvc;

namespace Service.ModelService
{
    public class RoleService : AbstractService<Role, int>
    {
        private IValidationDictionary _validationDictionary;
        public RoleService()
        {
            _validationDictionary = new ModelStateWrapper(new ModelStateDictionary());
        }
         public RoleService(IValidationDictionary validation) {
            _validationDictionary = validation;
        }
        public bool ValidateRole(Role RoleToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
