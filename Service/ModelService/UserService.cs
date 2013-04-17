using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;
using System.Web.Mvc;
using System.Web;

using System.IO;

namespace PHD.Service.ModelService
{
    public class UserService : AbstractService<User, int>
    {
        private IValidationDictionary _validationDictionary;
        public UserService()
        {
            _validationDictionary = new ModelStateWrapper(new ModelStateDictionary());
        }
        public UserService(IValidationDictionary validation) {
            _validationDictionary = validation;
        }
        public bool ValidateUser(User UserToValidate)
        {
            return _validationDictionary.IsValid;
        }
       
        
    }
}
