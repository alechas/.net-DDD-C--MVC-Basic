using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHD.Infrastructure.Helper
{

    public class SmtpException : System.Exception
    {
        private string message;
        public SmtpException(string str)
        {
            message = str;
        }
        public string What()
        {
            return message;
        }
    };
}
