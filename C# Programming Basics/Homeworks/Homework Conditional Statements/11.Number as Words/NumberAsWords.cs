using System;
class NumberAsWords
{
    static void Main()
    {
        //Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation. 
        //Examples:
        //numbers	number as words
        //0	        Zero
        //9	        Nine
        //10	    Ten
        //12	    Twelve
        //19	    Nineteen
        //25	    Twenty five
        //98	    Ninety eight
        //273	    Two hundred and seventy three
        //400	    Four hundred
        //501	    Five hundred and one
        //617	    Six hundred and seventeen
        //711	    Seven hundred and eleven
        //999	    Nine hundred and ninety nine

        int number = int.Parse(Console.ReadLine());
        string strNum = "";
        if ((number < 0) | (number > 999))
        {
            Console.WriteLine("Invalid number!");
            return;
        }
        else
        {
            int hundreds = (number / 100) % 10;
            int tens = (number / 10) % 10;
            int ones = number % 10;
            
            switch (hundreds)
            {
                case 1:
                    strNum = "one hundred ";
                    break;
                case 2:
                    strNum = "two hundred ";
                    break;
                case 3:
                    strNum = "three hundred ";
                    break;
                case 4:
                    strNum = "four hundred ";
                    break;
                case 5:
                    strNum = "five hundred ";
                    break;
                case 6:
                    strNum = "six hundred ";
                    break;
                case 7:
                    strNum = "seven hundred ";
                    break;
                case 8:
                    strNum = "eight hundred ";
                    break;
                case 9:
                    strNum = "nine hundred ";
                    break;
                default :
                    break;
            }
            if ((hundreds != 0) & ((tens != 0) | (ones != 0)))
            {
                strNum += "and ";
            }
            switch (tens)
            {
                case 2:
                    strNum += "twenty ";
                    break;
                case 3:
                    strNum += "thirty ";
                    break;
                case 4:
                    strNum += "fourty ";
                    break;
                case 5:
                    strNum += "fifty ";
                    break;
                case 6:
                    strNum += "sixty ";
                    break;
                case 7:
                    strNum += "seventy ";
                    break;
                case 8:
                    strNum += "eighty ";
                    break;
                case 9:
                    strNum += "ninety ";
                    break;
                default :
                    break;
            }
            if (tens != 1)
            {
                switch (ones)
                {
                    case 1:
                        strNum += "one";
                        break;
                    case 2:
                        strNum += "two";
                        break;
                    case 3:
                        strNum += "three";
                        break;
                    case 4:
                        strNum += "four";
                        break;
                    case 5:
                        strNum += "five";
                        break;
                    case 6:
                        strNum += "six";
                        break;
                    case 7:
                        strNum += "seven";
                        break;
                    case 8:
                        strNum += "eight";
                        break;
                    case 9:
                        strNum += "nine";
                        break;
                    default :
                        break;
                }
            }
            else
            {
                switch (ones)
                {
                    case 0:
                        strNum += "ten";
                        break;
                    case 1:
                        strNum += "eleven";
                        break;
                    case 2:
                        strNum += "twelve";
                        break;
                    case 3:
                        strNum += "thirteen";
                        break;
                    case 4:
                        strNum += "fourteen";
                        break;
                    case 5:
                        strNum += "fifteen";
                        break;
                    case 6:
                        strNum += "sixteen";
                        break;
                    case 7:
                        strNum += "seventeen";
                        break;
                    case 8:
                        strNum += "eighteen";
                        break;
                    case 9:
                        strNum += "nineteen";
                        break;
                    default :
                        break;
                }
            }
            if (number == 0)
            {
                strNum = "zero";
            }
        }
        char[] firstLetter = strNum.ToCharArray();
        firstLetter[0] = Char.ToUpper(firstLetter[0]);
        Console.WriteLine(firstLetter);
    }
}

