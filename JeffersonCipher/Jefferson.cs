using System;
using System.Text;

namespace JeffersonCipher
{
    internal class Jefferson
    {
        //public static int N { get; set; }
        //public string Text { get; set; }
        //public static int[] Disks = ShuflleN(N);
        public Jefferson()
        {
        }
        private int shift;
        private char[,] disks;
        private int[] numbers;
        StringBuilder encrypted = new StringBuilder();
        StringBuilder decrypted = new StringBuilder();
        public void Encrypt(int n, string text)
        {
            numbers = ShuflleN(n);
            Console.WriteLine("Encryption key is: ");
            foreach(var nr in numbers)
                Console.Write(nr+" ");
            disks = new char[26, n];
            string letters;
            for (int i=0;i<n;i++)
            {
                letters = ShuffleAlphabet();
                for (int j = 0; j < 26; j++)
                    disks[j, i] = letters[j];
            }
            Console.WriteLine("\nDisks are (in 1->n order): ");
            for(int i=0;i<26;i++)
            {
                for(int j=0;j<n;j++)
                    Console.Write(disks[i,j]+"   " );
                Console.WriteLine();
            }
            Console.WriteLine("\nBy the key, disks are: ");
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(disks[i,numbers[j]-1]+"   ");
                Console.WriteLine();
            }
            
            int indexOfLetter=-1;
            Random rnd = new Random();
            shift = rnd.Next(1, n);
            Console.WriteLine(shift);
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<26;j++)
                {
                    if(disks[j,numbers[i]-1]==text[i])
                    {
                        indexOfLetter = j;
                        break;
                    }
                }
                if(indexOfLetter==25)
                    encrypted = encrypted.Append(disks[shift, numbers[i]-1]);
                else
                    encrypted = encrypted.Append(disks[indexOfLetter + shift, numbers[i]-1]);
            }
            Console.WriteLine(encrypted);
            
        }

       public void Decrypt(int n)
        {
            int indexOfLetter = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (disks[j, numbers[i] - 1] == encrypted[i])
                    {
                        indexOfLetter = j;
                        break;
                    }
                }
                if (indexOfLetter == 0)
                    decrypted = decrypted.Append(disks[25-shift, numbers[i] - 1]);
                else
                    decrypted = decrypted.Append(disks[indexOfLetter - shift, numbers[i] - 1]);
            }
            Console.WriteLine(decrypted);
        }

        private static string ShuffleAlphabet()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] buffer = letters.ToCharArray();
            Random rnd = new Random();
            int j;

            for (int i = 25; i > 0; i--)
            {
                j = rnd.Next(i + 1);
                (buffer[i], buffer[j]) = (buffer[j], buffer[i]);
            }
            letters = new String(buffer);
            return letters;
        }

        private static int[] ShuflleN(int n)
        {
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
                numbers[i] = i + 1;

            Random rnd = new Random();
            int j;

            for(int i=n-1;i>=0;i--)
            {
                j = rnd.Next(i + 1);
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }
            return numbers;
        }
    }
}