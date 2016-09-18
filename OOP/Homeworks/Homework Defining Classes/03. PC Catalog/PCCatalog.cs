using System;
using System.Collections.Generic;
using System.Linq;

class PCCatalog
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        List<Computer> Computers = new List<Computer>();

        Computer lenovo = new Computer("Lenovo Yoga 2 Pro",
            new Component("Processor", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 500m),
            new Component("Graphics Card", "Intel HD Graphics 4400", 257.40m),
            new Component("HDD", "128GB SSD", 230.57m),
            new Component("Screen", @"13.3"" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", 88m));

        Computer hp = new Computer("HP 255 G2",
            new Component("Processor", 230.85m),
            new Component("Graphics Card", "AMD Radeon HD 8330", 187.75m));

        Computer lenovo2 = new Computer("Lenovo Yoga 3 Pro",
            new Component("Processor", "Intel Core M 5Y71 Processor(1.20GHz 1600MHz 4mb)", 725m),
            new Component("Graphics Card", "Intel® HD Graphics 5300", 375.25m),
            new Component("HDD", "512GB Solid State Hard Drive", 450m));

        Computers.Add(lenovo);
        Computers.Add(hp);
        Computers.Add(lenovo2);

        var result = Computers.OrderBy(computer => computer.Price);
        foreach (var computer in result)
        {
            Console.WriteLine(computer);
        }
    }
}

