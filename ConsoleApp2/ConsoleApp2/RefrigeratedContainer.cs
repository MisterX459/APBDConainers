namespace ConsoleApp2;

public class RefrigeratedContainer : Container
{
    
    private static int RefrigeratedConCounter = 0;
    public string ProductType { get; private set; }
    public double Temperature { get; private set; }
    
    protected override int GetConCounter()
    {
        return RefrigeratedConCounter;
    }
    
    protected override void IncrementConCounter()
    {
        RefrigeratedConCounter++;
    }

    private static readonly Dictionary<string, double> ProductTemperatureMap = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public RefrigeratedContainer(double cargoWeight, string containerType, double containerDepth,
        double containerHeight, double containerWeight, double cargoMax, string productType, double temperature)
        : base(cargoWeight, containerType, containerDepth, containerHeight, containerWeight, cargoMax)
    {
        ProductType = productType;
        Temperature = temperature;

        ValidateTemperature();
    }

    private void ValidateTemperature()
    {
        if (!ProductTemperatureMap.ContainsKey(ProductType))
        {
            throw new ArgumentException("Invalid product type");
        }

        double requiredTemperature = ProductTemperatureMap[ProductType];
        if (Temperature < requiredTemperature)
        {
            throw new ArgumentException($"Temperature cannot be lower than {requiredTemperature} for {ProductType}");
        }
    }

    public override void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
    }
}
