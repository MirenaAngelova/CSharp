using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37.Magic_Card
{
    class MagicCard
    {
        static void Main(string[] args)
        {
            string[] hand = Console.ReadLine().Split();
            string oddEven = Console.ReadLine();
            string magic = Console.ReadLine();
            //string magicFace = magic.Replace("[SHDC]", String.Empty);
            string magicFace = magic.Substring(0, magic.Length - 1);
            string magicSuit = magic.Substring(magic.Length - 1);
            //string[] magicCard = magic.ToCharArray().Select(ch => ch.ToString()).ToArray();
            //string magicFace = magicCard[0]; don't work
            //string magicSuit = magicCard[1];
            List<string> cards =
                new List<string> { "*", "*", "2", "3", "4", "5", "6", "7", "8", "9", "10", "*", "J", "Q", "K", "A" };
            long sum = 0;
            int oddEvenInt = oddEven == "even" ? 0 : 1;
            for (int i = oddEvenInt; i < hand.Length; i += 2)
            {
                string hands = hand[i];
                string handFace = hands.Substring(0, hands.Length - 1);
                string handSuit = hands.Substring(hands.Length - 1);
                //string[] card = hands.ToCharArray().Select(ch => ch.ToString()).ToArray();
                //string handFace = card[0]; don't work
                //string handSuit = card[1];

                var cardInt = cards.IndexOf(handFace);
                if (handFace == magicFace)
                {
                    sum += cardInt * 30;
                }
                else if (handSuit == magicSuit)
                {
                    sum += cardInt * 20;
                }
                else
                {
                    sum += cardInt * 10;
                }

            }

            Console.WriteLine(sum);
        }
    }
}
