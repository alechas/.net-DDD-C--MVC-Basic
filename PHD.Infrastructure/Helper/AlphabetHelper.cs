using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHD.Infrastructure.Helper
{
    public class AlphabetHelper
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public char NextLetter(char[] letter)
        {
            int id = alphabet.IndexOf(letter[0]);
            char c = alphabet[(alphabet.IndexOf(Convert.ToChar(letter[0])) % alphabet.Length)+1];
            return alphabet[(alphabet.IndexOf(Convert.ToChar(letter[0])) % alphabet.Length) + 1];
        }

    }
}
