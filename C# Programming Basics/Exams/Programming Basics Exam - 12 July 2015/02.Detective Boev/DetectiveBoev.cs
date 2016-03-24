using System;

namespace _02.Detective_Boev
{
    class DetectiveBoev
    {
        static void Main(string[] args)
        {
            string secretWord = Console.ReadLine();
            string encryptedMessage = Console.ReadLine();
            int sumWord = 0;
            int mask = 0;
            for (int i = 0; i < secretWord.Length; i++)
            {
                sumWord += secretWord[i];
            }
            //Console.WriteLine(sumWord);
            while (sumWord > 0)
            {
                mask += sumWord % 10;
                sumWord /= 10;
                int result = 0;
                while (mask > 0)
                {
                    result += mask % 10;
                    mask /= 10;
                }
                mask = result;
            }
            //Console.WriteLine(mask);
            string message = "";
            for (int i = 0; i < encryptedMessage.Length; i++)
            {

                if ((char)encryptedMessage[i] % mask == 0)
                {
                    message += (char)(encryptedMessage[i] + mask);
                }
                else
                {
                    message += (char)(encryptedMessage[i] - mask);
                }
            }
            //|wfvohyfqX#hodzwclV //;7*8&yioyg<&mtossglmulV
            //Console.WriteLine(message);
            char[] arr = message.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(arr);
        }
    }
}
