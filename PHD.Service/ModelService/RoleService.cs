using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;
using System.Web.Mvc;

namespace PHD.Service.ModelService
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
