using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
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
