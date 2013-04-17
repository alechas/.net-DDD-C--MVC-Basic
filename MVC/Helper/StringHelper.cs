using System;
namespace PHD.MVC.Helper
{
    public class StringHelper
    {
        public string sep(string s)
        {
            int l = s.IndexOf("@");
            if (l > 0)
            {
                return s.Substring(0, l);
            }
            return "";

        }

        public bool checkEmail(string s)
        {
            try
            {
                int l = s.IndexOf("@");
                if (l > 0)
                {
                    return true;
                }
                return false;
            }
            catch 
            {

                return false;
            }
        }
        public string GetLast(String s, int tail_length)
        {
            if (tail_length >= s.Length)
                return s;
            return s.Substring(s.Length - tail_length);
        }
    }
}