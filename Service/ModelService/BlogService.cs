using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Abstract;
using Session.Classes;
using Service.Validation;

namespace Service.ModelService
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
