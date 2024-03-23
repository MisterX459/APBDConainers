namespace ConsoleApp2;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double cargoWeight, string containerType, double containerDepth,
        double containerHeight, double containerWeight, double cargoMax, bool isHazardous)
        : base(cargoWeight, containerType, containerDepth, containerHeight, containerWeight, cargoMax)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double cargoWeight)
    {
        double maxCapacityPercentage = IsHazardous ? 0.5 : 0.9;
        if ((CargoWeight + cargoWeight) > (CargoMax * maxCapacityPercentage))
        {
            throw new Exception("Attempt to perform a dangerous operation: Container overload");
        }

        base.Load(cargoWeight);
    }

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazardous situation detected! Container number: {containerNumber}");
    }
}