using System;

namespace VigenereCipher__Polyalphabetic_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the text you want to be encrypted and decrypted, please!");
            string Text = Console.ReadLine();
            Console.WriteLine("\nInsert the keyword, please!");
            string Keyword = Console.ReadLine();
            VigenereCipher vigenere = new VigenereCipher(Text, Keyword);
            string encrypted = vigenere.Encrypt();
            Console.WriteLine("\nEncrypted text is: "+ encrypted);
            Console.WriteLine("\nDecrypted text is: " + vigenere.Decrypt(encrypted));
        }

    }
}
