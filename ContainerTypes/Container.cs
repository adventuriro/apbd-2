namespace apbd.ContainerTypes;

public abstract class Container
{
    public Container(
        char containerType,
        double height,
        double weight,
        double depth,
        double maxLoad
    )
    {
        SerialNumber = SerialNumberGenerator.Default.New(containerType);
        LoadedMass = 0;
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxLoad = maxLoad;
    }
    
    public string SerialNumber { get; }
    public double Height { get; }
    public double Weight { get; }
    public double Depth { get; }
    public double MaxLoad { get; }
    public double LoadedMass { get; protected set; }

    public virtual void Empty()
    {
        LoadedMass = 0;
    }

    public virtual void Load(double mass)
    {
        if (LoadedMass + mass > MaxLoad)
        {
            throw new OverfillException();
        }
        LoadedMass += mass;
    }

    public override string ToString()
    {
        return $"{GetType().Name}(Serial={SerialNumber}, LoadedMass={LoadedMass}, Weight={Weight}, Height={Height}, Depth={Depth}, MaxLoad={MaxLoad})";
    }
}