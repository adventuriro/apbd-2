namespace Containers;

public class RefrigeratorContainer : Container
{
    public double temperature { get; set; }
    public string loadedProduct { get; set; }

    public RefrigeratorContainer(double cargoMass, double height, double ownWeight, double depth, double maxLoadMass,
        string loadedProduct, double temperature) : base(cargoMass, height, ownWeight, depth, maxLoadMass, 'C')
    {
        this.temperature = temperature;
        this.loadedProduct = loadedProduct;

        if (!ProductController.checkIfValidProduct(loadedProduct))
        {
            throw new ArgumentException($"{loadedProduct} is not a valid product to load into refrigerator container!");
        }

        if (temperature < ProductController.getProductTemperature(loadedProduct))
        {
            throw new ArgumentException($"Refrigerator container temperature is too low to transport {loadedProduct}");
        }
    }

    public override string ToString()
    {
        return
            $"Refrigerator Container -> Serial No: {serialNumber}; Cargo Mass: {cargoMass} kg; Height: {height} cm; Own Weight: {ownWeight} kg; Depth: {depth} cm; Max Load: {maxLoadMass} kg; Loaded Product: {loadedProduct}; Temperature: {temperature}\u00b0C";
    }
}