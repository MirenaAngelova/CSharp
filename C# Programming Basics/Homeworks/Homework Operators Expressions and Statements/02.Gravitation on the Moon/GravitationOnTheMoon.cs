using System;
class GravitationOnTheMoon
{
    static void Main()
    {
        //The gravitational field of the Moon is approximately 17% of that on the Earth. Write a program 
        //that calculates the weight of a man on the moon by a given weight on the Earth. Examples:
        //weight	weight on the Moon
        //86	    14.62
        //74.6	    12.682
        //53.7	    9.129

        float earthWeight = float.Parse(Console.ReadLine());
        Console.WriteLine("{0:f3}",earthWeight * 0.17); //earthWeight * 17 / 100
    }
}

