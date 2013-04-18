using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class BlogService : AbstractService<Blog, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateBlog(Blog BlogToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
