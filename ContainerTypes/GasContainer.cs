namespace apbd.ContainerTypes;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(
        GasType loadType,
        double height,
        double weight,
        double depth,
        double maxLoad
    )
        : base('G', height, weight, depth, maxLoad)
    {
        LoadType = loadType;
    }
    
    public GasType LoadType { get; }

    public override void Empty()
    {
        LoadedMass *= 0.05;
    }

    public void NotifyDangerousEvent()
    {
        Console.WriteLine($"{GetType().Name}{{Serial={SerialNumber}, Load={LoadedMass}}}::NotifyDangerousEvent()");
    }
}