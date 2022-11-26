using System;

namespace JeffersonCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of disks:\nn= ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the text you want to encrypt:");
            string text = Console.ReadLine();
            if (text.Length != n)
                Console.WriteLine("Text length should be equal with the number of disks!");
            else
            {
                text = text.ToUpper();
                Jefferson jefferson = new Jefferson();
                jefferson.Encrypt(n,text);
                jefferson.Decrypt(n);
            }
        }
    }
}
