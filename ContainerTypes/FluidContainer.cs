namespace apbd.ContainerTypes;

public class FluidContainer : Container, IHazardNotifier
{
    public static readonly FluidType[] DangerousLoadTypes =
    {
        FluidType.HydrochloricAcid,
    }; 
        
    public FluidContainer(
        FluidType loadType,
        double height,
        double weight,
        double depth,
        double maxLoad
    )
        : base('F', height, weight, depth, maxLoad)
    {
        LoadType = loadType;
    }
    
    public FluidType LoadType { get; }

    public override void Load(double mass)
    {
        double allowedPcnt = DangerousLoadTypes.Contains(LoadType) ? 0.5 : 0.9;
        if ((LoadedMass + mass) > MaxLoad * allowedPcnt)
        {
            NotifyDangerousEvent();
            mass = MaxLoad * allowedPcnt;
        }
        base.Load(mass);
    }

    public void NotifyDangerousEvent()
    {
        Console.WriteLine($"{GetType().Name}{{Serial={SerialNumber}, Load={LoadedMass}}}::NotifyDangerousEvent()");
    }
}