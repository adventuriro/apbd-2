namespace apbd.ContainerTypes;

public class CoolerContainer : Container
{
    public CoolerContainer(
        SolidType loadType,
        double height,
        double weight,
        double depth,
        double maxLoad
    )
        : base('C', height, weight, depth, maxLoad)
    {
        LoadType = loadType;
    }
    
    public SolidType LoadType { get; }
}