

namespace ConsoleApp2;

public abstract class Container : IContainer
{
    public double CargoWeight { get; set; }
    public string SerialNumber { get; private set; }
    private static int ContainerCounter = 0;
    public string ContainerType;
        
    public double ContainerHeight { get; set; }
    public double ContainerWeight { get; set; }
    public double ContainerDepth { get; set; }
    public double CargoMax { get; set; }
    protected Container(double cargoWeight, string containerType, double containerDepth, 
        double containerHeight, double containerWeight, double cargoMax)
    {
        CargoWeight = cargoWeight;
        ContainerType = containerType;
        ContainerHeight = containerHeight;
        ContainerWeight = containerWeight;
        ContainerDepth = containerDepth;
        CargoMax = cargoMax;
        generateSerialNumber();
        CheckWeight();
    }

    protected abstract int GetConCounter();
    protected abstract void IncrementConCounter();
    private void generateSerialNumber()
    {
        int ConteinerCounter = GetConCounter();
        SerialNumber = $"KON-{ContainerType}-{(++ConteinerCounter).ToString()}";
        IncrementConCounter();
    }

    public virtual void Unload()
    {
        CargoWeight = 0;
    }

    public virtual void CheckWeight()
    {
        if (CargoWeight > CargoMax)
        {
            Unload();
            throw new Overfill();
        }
    }

    public virtual void Load(double cargoWeight)
    {
        if (CargoWeight+cargoWeight > CargoMax)
        {
            throw new Overfill();
        }

        CargoWeight += cargoWeight;
    }

   
}
