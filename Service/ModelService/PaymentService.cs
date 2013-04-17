using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Service.Abstract;
using PHD.Session.Classes;
using PHD.Service.Validation;

namespace PHD.Service.ModelService
{
    public class PaymentService : AbstractService<Payment, int>
    {
        private IValidationDictionary _validationDictionary;
        public bool ValidatePayment(Payment PaymentToValidate)
        {
            return _validationDictionary.IsValid;
        }
    }
}
