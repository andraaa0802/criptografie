using System;

namespace PlayfairCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce the text, please!");
            string text = Console.ReadLine();
            Console.WriteLine("Introduce the key, please!");
            string key = Console.ReadLine();
            Playfair playfair = new Playfair();
            string encrypted = playfair.Encrypt(text,key);
            Console.WriteLine("The encrypted text is: "+encrypted);
            Console.WriteLine("The decrypted text is: " + playfair.Decrypt(encrypted, key));
        }
    }
}
