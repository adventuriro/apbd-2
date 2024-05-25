namespace Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double pressure { get; set; }

    public GasContainer(double cargoMass, double height, double ownWeight, double depth, double maxLoadMass, double pressure) : base(cargoMass, height, ownWeight, depth, maxLoadMass, 'G')
    {   
        this.pressure = pressure;
    }

    public void notifyHazard(string containerSerialNumber)
    {
        Console.WriteLine($"Hazard in gas container -> {containerSerialNumber}");
    }
    
    public void unloadCargo()
    {
        cargoMass = cargoMass * 0.05;
    }
    
    public override string ToString()
    {
        return $"Gas Container -> Serial No: {serialNumber}; Cargo Mass: {cargoMass} kg; Height: {height} cm; Own Weight: {ownWeight} kg; Depth: {depth} cm; Max Load: {maxLoadMass} kg; Pressure: {pressure} PSI";
    }
}