namespace Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool isHazardous { get; set; }

    public LiquidContainer(double cargoMass, double height, double ownWeight, double depth, double maxLoadMass,
        bool isHazardous) : base(cargoMass, height, ownWeight, depth, maxLoadMass, 'L')
    {
        this.isHazardous = isHazardous;
    }

    public void loadCargo(double loadMass)
    {
        if (loadMass > maxLoadMass)
        {
            throw new OverfillException($"Container {serialNumber} max load mass was exceeded!");
        }

        if (isHazardous)
        {
            if ((loadMass + cargoMass) / maxLoadMass <= 0.5)
            {
                Console.WriteLine(
                    $"Hazardous materials can only take 50% of total loading capacity of container. The operation for container {serialNumber} was not performed.");
                return;
            }
        }
        else
        {
            if ((loadMass + cargoMass) / maxLoadMass <= 0.9)
            {
                Console.WriteLine(
                    $"Nonhazardous materials can only take 90% of total loading capacity of container. The operation for container {serialNumber} was not performed.");
                return;
            }
        }

        cargoMass = loadMass;
    }

    public void notifyHazard(string containerSerialNumber)
    {
        Console.WriteLine($"Hazard in liquid container -> {containerSerialNumber}");
    }

    public override string ToString()
    {
        return $"Liquid Container -> Serial No: {serialNumber}; Cargo Mass: {cargoMass} kg; Height: {height} cm; Own Weight: {ownWeight} kg; Depth: {depth} cm; Max Load: {maxLoadMass} kg; Is Hazardous?: {isHazardous}";
    }
}