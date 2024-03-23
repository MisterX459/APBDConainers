// See https://aka.ms/new-console-template for more information

using ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Ship Ship1 = new Ship(23, 150, 4500);
        Ship Ship2 = new Ship(50, 100, 3000);
        GasContainer gC = new GasContainer(200, "G", 20, 50, 175, 300, 10);
        LiquidContainer lC = new LiquidContainer(10, "L", 15, 40, 30, 300, true);
        RefrigeratedContainer rC = new RefrigeratedContainer(30, "C", 50, 60, 75, 70, "Sausages", 5.0);
        GasContainer gC2 = new GasContainer(25, "G", 35, 55, 175, 300, 23);
        Ship1.LoadContainers(new List<Container> { gC, lC });
        Ship2.LoadContainers(new List<Container> { rC, gC2 });
        Console.WriteLine(Ship1);
        Console.WriteLine(Ship2);
        Ship1.unload(gC.SerialNumber);
        Ship2.Remove(rC.SerialNumber);
        Ship2.Replace(gC2.SerialNumber, lC);
        Ship1.changeShip(Ship2, rC.SerialNumber);
        Console.WriteLine("===============================================");
        Console.WriteLine(Ship1);
        Console.WriteLine(Ship2);
    }
}
    
