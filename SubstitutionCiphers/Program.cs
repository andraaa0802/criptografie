using System;

namespace SubstitutionCiphers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What cipher do you want to use? Enter 1, 2, 3 or 4, please!");
            Console.WriteLine("1. Caesar cipher");
            Console.WriteLine("2. ROT13 cipher");
            Console.WriteLine("3. ShiftByN cipher");
            Console.WriteLine("4. Monoalphabetic substitution");
            int option;
            option = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the text you want to encrypt!");
            string text = Console.ReadLine();
            string EncryptedText, DecryptedText;
            switch(option)
            {
                //programul face atat criptarea, cat si decriptarea textului initial 
                //ex1: pentru "hello", cu cifrul lui cezar, se va afisa criptarea "khoor" si decriptarea "ebiil"
                //ex2: pentru "khoor", cu cifrul lui cezar, se va afisa criptarea "nkrru" si descriptarea "hello"
                case 1:
                    CaesarCipher caesar = new CaesarCipher(3, text);
                    EncryptedText=caesar.Encrypt();
                    Console.WriteLine("Encrypted text is: " + EncryptedText);
                    DecryptedText=caesar.Decrypt();
                    Console.WriteLine("Decrypted text is: " + DecryptedText);
                    break;
                case 2:
                    ROT13 rot13 = new ROT13(13, text);
                    EncryptedText = rot13.Encrypt();
                    Console.WriteLine("Encrypted text is: "+EncryptedText);
                    DecryptedText = rot13.Decrypt();
                    Console.WriteLine("Decrypted text is: " + DecryptedText);
                    break;
                case 3:
                    Console.WriteLine("Introduce the value for n!");
                    int n = int.Parse(Console.ReadLine());
                    ShiftByN shift = new ShiftByN(n, text);
                    EncryptedText = shift.Encrypt();
                    Console.WriteLine("Encrypted text is: "+EncryptedText);
                    DecryptedText = shift.Decrypt();
                    Console.WriteLine("Decrypted text is: " + DecryptedText);
                    break;
                case 4:
                    MonoalphabeticSubstitution monoalphabetic = new MonoalphabeticSubstitution(text);
                    EncryptedText = monoalphabetic.Encrypt();
                    Console.WriteLine("Encrypted text is: "+EncryptedText);
                    DecryptedText = monoalphabetic.Decrypt();
                    Console.WriteLine("Decrypted text is: " + DecryptedText);
                    break;
                default:
                    Console.WriteLine("You didn't chose a right value!");
                    break;

            }
        }
    }
}
