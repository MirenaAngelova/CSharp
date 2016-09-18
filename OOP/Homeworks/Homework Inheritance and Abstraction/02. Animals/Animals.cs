using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Animals
{
    class Animals
    {
        static void Main()
        {
            Dog balkan = new Dog("Balkan", 4, "male");
            Dog cherry = new Dog("Cherry", 2, "female");
            Dog cerber = new Dog("Cerber", 7, "male");

            Frog green = new Frog("Green", 1, "female");
            Frog poison = new Frog("Poison", 2, "male");

            Cat kitty = new Kitten("Kitty", 4);
            Cat tom = new Tomcat("Tom", 3);
            List<Animal> animals = new List<Animal>()
            {
                balkan,
                cherry,
                cerber,
                green,
                poison,
                kitty,
                tom,
            };
            var kindOfAnimal = from animal in animals
                group animal by animal.GetType().Name
                into g
                select new {Kind = g.Key, AverageAge = g.ToList().Average(a => a.Age)};
            foreach (var animal in kindOfAnimal)
            {
                Console.WriteLine("{0}s - average age: {1:N2}", animal.Kind, animal.AverageAge);
            }
            balkan.ProduceSound();
            cherry.ProduceSound();
            cerber.ProduceSound();

            green.ProduceSound();
            poison.ProduceSound();

            kitty.ProduceSound();
            tom.ProduceSound();
        }
    }
}
