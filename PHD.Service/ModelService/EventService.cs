using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class EventService : AbstractService<Event, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidateEvent(Event EventToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
