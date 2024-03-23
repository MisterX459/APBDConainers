namespace ConsoleApp2;

public class LiquidContainer : Container, IHazardNotifier
{
    private static int LiquidConCounter = 0;
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double cargoWeight, string containerType, double containerDepth,
        double containerHeight, double containerWeight, double cargoMax, bool isHazardous)
        : base(cargoWeight, containerType, containerDepth, containerHeight, containerWeight, cargoMax)
    {
        IsHazardous = isHazardous;
    }
    protected override int GetConCounter()
    {
        return LiquidConCounter;
    }
    protected override void IncrementConCounter()
    {
       LiquidConCounter++;
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