using System;
using System.Collections.Generic;

namespace _01.Largest_Common_End
{
    public class LargestCommonEnd
    {
        public static void Main()
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            int getMinLength = Math.Min(firstArray.Length, secondArray.Length);
            
            List<string> leftCommondEnd = new List<string>();
            int leftEnd = FindLeftCoomondEnd(firstArray, secondArray, getMinLength, leftCommondEnd); 

            // firstArray.Reverse(); use common method for left and right
            // secondArray.Reverse();

            List<string> rightCommondEnd = new List<string>();
            int rightEnd = FindRightCoomondEnd(firstArray, secondArray, getMinLength, rightCommondEnd);

            if (leftCommondEnd.Count== 0 && rightCommondEnd.Count == 0)
            {
                Console.WriteLine($"No common {0} words at the left and right");
                return;
            }

            if (IsLeftGreaterThanRight(leftCommondEnd, rightCommondEnd))
            {
                Console.WriteLine(
                    $"The largest common end {leftEnd} is at the left: {string.Join(" ", leftCommondEnd)}");
            }
            else
            {
                rightCommondEnd.Reverse();
                Console.WriteLine(
                    $"The largest common end {rightEnd} is at the right: {string.Join(" ", rightCommondEnd)}"); 
            }
        }

        private static bool IsLeftGreaterThanRight(
            List<string> leftCommondEnd, List<string> rightCommondEnd)
        {
            if (leftCommondEnd.Count >= rightCommondEnd.Count)
            {
                return true;
            }

            return false;
        }

        private static int FindRightCoomondEnd(
            string[] firstArray, string[] secondArray, int getMinLength, List<string> rightCommondEnd)
        {
            int index = 0;
            int firstLength = firstArray.Length - 1;
            int secondLength = secondArray.Length - 1;
            while (index < getMinLength - 1 && firstArray[firstLength] == secondArray[secondLength])
            {
                rightCommondEnd.Add(firstArray[firstLength]);
                firstLength--;
                secondLength--;

                if (index == getMinLength - 2)
                {
                    rightCommondEnd.Add(firstArray[index - 1]);
                }

                index++;
            }

            return index;
        }

        private static int FindLeftCoomondEnd(
            string[] firstArray, string[] secondArray, int getMinLength, List<string> leftCommondEnd)
        {
            int index = 0;
;            while (index < getMinLength - 1 && firstArray[index] == secondArray[index])
            {
                leftCommondEnd.Add(firstArray[index]);
                if (index == getMinLength - 2)
                {
                    leftCommondEnd.Add(firstArray[index + 1]);
                }

                index++;
            }

            return index;
        }
    }
}
