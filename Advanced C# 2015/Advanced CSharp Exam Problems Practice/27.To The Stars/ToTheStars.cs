using System;
using System.Linq;
    class ToTheStars
    {
        static void Main()
        {
            string[] starFirst = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string starFirstName = starFirst[0].ToLower();
            double starFirstX = double.Parse(starFirst[1]);
            double starFirstY = double.Parse(starFirst[2]);

            string[] starSecond = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string starSecondName = starSecond[0].ToLower();
            double starSecondX = double.Parse(starSecond[1]);
            double starSecondY = double.Parse(starSecond[2]);

            string[] starThird = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string starThirdtName = starThird[0].ToLower();
            double starThirdX = double.Parse(starThird[1]);
            double starThirdY = double.Parse(starThird[2]);

            string[] normandy = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double initialX = double.Parse(normandy[0]);
            double initialY = double.Parse(normandy[1]);

            int n = int.Parse(Console.ReadLine());

            for (double i = initialY; i < initialY + n + 1; i++)
            {
                bool insideFirst = (initialX >= starFirstX - 1 && initialX <= starFirstX + 1 &&
                    i >= starFirstY - 1 && i <= starFirstY + 1);
                bool insideSecond = (initialX >= starSecondX - 1 && initialX <= starSecondX + 1 &&
                   i >= starSecondY - 1 && i <= starSecondY + 1);
                bool insideThird = (initialX >= starThirdX - 1 && initialX <= starThirdX + 1 &&
                   i >= starThirdY - 1 && i <= starThirdY + 1);

                if (insideFirst)
                {
                    Console.WriteLine(starFirstName);
                }
                else if (insideSecond)
                {
                    Console.WriteLine(starSecondName);
                }
                else if (insideThird)
                {
                    Console.WriteLine(starThirdtName);
                }
                else 
                {
                    Console.WriteLine("space");
                }
            }

        }
    }

