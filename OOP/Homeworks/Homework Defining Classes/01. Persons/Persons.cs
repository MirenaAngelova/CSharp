using System;
 public class Persons
{
    static void Main()
    {
        //Person anonymous = new Person("", 12, "noname@abv.bg");
        //Console.WriteLine(anonymous);
        //Person young = new Person("Young", -15, "yong@abv.bg");
        //Console.WriteLine(young);
        //Person old = new Person("Old", 101, "old@abv.bg");
        //Console.WriteLine(old);
        Person unemailed = new Person("Unemailed", 21);
        Console.WriteLine(unemailed);
        Person normal = new Person("Normal", 1, "normal@abv.bg");
        Console.WriteLine(normal);
    }
}


