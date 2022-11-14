using System.Text;
using System;

namespace SubstitutionCiphers
{
    internal class MonoalphabeticSubstitution
    {
        public string Text { get; set; }
        public static string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        public static string Letters = Shuffle(Alphabet);
        public MonoalphabeticSubstitution (string text)
        {
            Text = text;
        }
        public string Encrypt()
        {
            string EncryptedText = "";
            Console.WriteLine( "\nI'll use the following permutation: \n" + Alphabet + "\n" + Letters + "\n"); 
            for (int i=0;i<Text.Length;i++)
            {
                if (char.IsLetter(Text[i]))
                {
                    if (Text[i] >= 'A' && Text[i] <= 'Z')
                        EncryptedText+=Char.ToUpper(Letters[Char.ToLower(Text[i])-97]);
                    else 
                        EncryptedText+=Letters[Text[i]-97];
                }
                else
                    EncryptedText+=Text[i];
            }
            return EncryptedText;
        }

        public string Decrypt()
        {
            string DecryptedText = "";

            for (int i = 0; i < Text.Length; i++)
            {
                if (char.IsLetter(Text[i]))
                {
                    int j = Letters.IndexOf(Char.ToLower(Text[i]));
                    if (Text[i] >= 'A' && Text[i] <= 'Z')
                        DecryptedText += Char.ToUpper(Alphabet[j]);
                    else
                        DecryptedText += Alphabet[j];
                }
                else
                    DecryptedText += Text[i];
            }
            return DecryptedText;
        }

        public static string Shuffle(string lett)
        {
            char[] buffer = lett.ToCharArray();
            Random rnd = new Random();
            int j;

            for (int i = 25; i > 0; i--)
            {
                j = rnd.Next(i + 1);
                (buffer[i], buffer[j]) = (buffer[j], buffer[i]);
            }
            lett = new String(buffer);
            return lett;
        }
    }
}