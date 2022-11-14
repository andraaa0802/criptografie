using System;
namespace VigenereCipher__Polyalphabetic_
{
    internal class VigenereCipher
    {
       public static string Text { get; set; }
       public static string Keyword { get; set; }

       public VigenereCipher(string text, string keyword)
       {
            Text = text;
            Keyword = keyword;
       }
       
       public string Encrypt()
       {
            string NewKeyword = KeyGenerator(Text, Keyword);
            string EncryptedText = "";
            for (int i = 0; i < Text.Length; i++)
            {
                if (Char.IsLetter(Text[i]))
                {
                    int letter = ((Text[i]) + NewKeyword[i]) % 26;
                    letter += 'A';
                    EncryptedText += (char)(letter);
                }
                else
                    EncryptedText += Text[i];
            }
            return EncryptedText;
       }

        public string Decrypt(string text)
        {
            string NewKeyword = KeyGenerator(Text, Keyword);
            string DecryptedText = "";
            for (int i = 0; i < text.Length && i<NewKeyword.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    int letter = (text[i] - NewKeyword[i] + 26) % 26;
                    letter += 'A';
                    DecryptedText += (char)(letter);
                }
                else
                    DecryptedText += text[i];
            }
            return DecryptedText;
        }

        public string KeyGenerator(string text, string keyword)
        {
            //in functia aceasta, se readauga in cuvantul cheie, insusi cuvantul cheie sau litere din acesta
            //pana cand are aceeasi lungime cu textul de criptat
            //ex: pt. text="securitate", keyword="qwerty", keyword va deveni "qwertyqwer"
            
            int InitialKeyLength = keyword.Length;
            for (int i = 0; i <= InitialKeyLength ; i++)
            {
                if (i == InitialKeyLength)
                    i = 0;
                if (keyword.Length == text.Length)
                    break;
                keyword += (keyword[i]);
            }
            return keyword;
        }
    }
}