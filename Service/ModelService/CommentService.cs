using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Abstract;
using Session.Classes;
using Service.Validation;

namespace Service.ModelService
{
    public class CommentService : AbstractService<Comment, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateComment(Comment CommentToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
