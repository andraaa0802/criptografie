using System;
using System.Text;

namespace SubstitutionCiphers
{
    public class ShiftByN
    {
        public int Key { get; set; }
        public string Text { get; set; }
        public static char[] buffer;

        public ShiftByN(int key, string text)
        {
            Key = key;
            Text = text;
        }

        public string Encrypt()
        {
            buffer= Text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                if(char.IsLetter(buffer[i]))
                {
                    char upper = char.IsUpper(buffer[i]) ? 'A' : 'a';
                    buffer[i] = (char)((buffer[i] + Key - upper) % 26 + upper);
                }
                    
            }
            return new String(buffer);
        }

        public string Decrypt()
        {
            buffer = Text.ToCharArray(); //daca inlaturam aceasta linie, decriptarea se va face textului tocmai criptat si nu textului initial
            for (int i = 0; i < buffer.Length; i++)
            {
                if (char.IsLetter(buffer[i]))
                {
                    char upper = char.IsUpper(buffer[i]) ? 'A' : 'a';
                    buffer[i] = (char)((buffer[i] + (26-Key) - upper) % 26 + upper);
                }
            }
            return new String(buffer);
        }
    }
}