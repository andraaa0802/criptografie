using System;
using System.Collections.Generic;
using System.Text;

namespace SubstitutionCiphers
{
    internal class CaesarCipher : ShiftByN 
    {
        public CaesarCipher(int key, string text): base(key, text)
        {
            
        }
    }
}
