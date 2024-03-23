namespace ConsoleApp2;
public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }

    public GasContainer(double cargoWeight, string containerType, double containerDepth,
        double containerHeight, double containerWeight, double cargoMax, double pressure)
        : base(cargoWeight, containerType, containerDepth, containerHeight, containerWeight, cargoMax)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        
        CargoWeight *= 0.95;
    }

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazardous situation detected! Container number: {containerNumber}");
    }

    public override void Load(double cargoWeight)
    {
        if (CargoWeight + cargoWeight > CargoMax)
        {
            throw new Exception("Cargo weight exceeds allowable payload");
        }

        base.Load(cargoWeight);
    }
}
