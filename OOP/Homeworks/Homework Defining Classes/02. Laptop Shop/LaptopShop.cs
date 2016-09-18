using System;
class LaptopShop
{
    static void Main()
    {
        Laptop hp = new Laptop("HP 250 G2", 699.00m);
        Console.WriteLine(hp);

        Laptop lenovo = new Laptop("Lenovo Yoga 2 Pro", "Lenovo", 
            "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8, 
            "Intel HD Graphics 4400", "128GB SSD", @"13.3"" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", 
            new Battery("Li-Ion, 4-cells, 2550 mAh", 4.5), 2259m);
        Console.WriteLine(lenovo);

        Laptop hp2 = new Laptop("HP 255 G2", "Hewlett-Packard", "AMD A4-5000 (4-core, 1.50 Ghz, 2MB cache)", 4, 
            "AMD Radeon HD 8330", "500GB HDD", @"15.6"" (39.62 cm) - 1366x768, opaque", 494.34m);
        Console.WriteLine(hp2);

        Laptop lenovo2 = new Laptop("Lenovo Yoga 3 Pro", "Lenovo", "Intel Core M 5Y71 Processor(1.20GHz 1600MHz 4mb)", 8,
            "Intel® HD Graphics 5300", 1700.99m);
        Console.WriteLine(lenovo2);
    }
}

