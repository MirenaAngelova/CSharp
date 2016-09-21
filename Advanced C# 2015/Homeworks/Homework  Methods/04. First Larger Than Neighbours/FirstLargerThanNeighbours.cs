using System;
class FirstLargerThanNeighbours
{
    static void Main()
    {
        //Write a method that returns the index of the first element in array that is larger than its neighbours, 
        //or -1 if there's no such element. Use the method from the previous exercise in order to re.

        int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
        int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] sequenceThree = { 1, 1, 1 };

        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceOne));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceTwo));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceThree));
    }
    private static int GetIndexOfFirstElementLargerThanNeighbours(int[] sequence)
    {
        for (int i = 0; i < sequence.Length; i++)
        {
            if ((i == 0 && sequence[i + 1] < sequence[i]) ||
            (i == sequence.Length - 1 && sequence[i - 1] < sequence[i]) || 
            ((i != 0 && i != sequence.Length - 1) && sequence[i - 1] < sequence[i] && sequence[i] > sequence[i + 1]))
            {
                return i;
            }
        }
        return -1;
    }
}