using apbd.ContainerTypes;

namespace apbd;

public class Program
{
    public Program()
    { }

    public static void Main(string[] args)
        => new Program().Run();

    private void Run()
    {
        Ship sA = new Ship();
        Ship sB = new Ship();

        Container cA = new CoolerContainer(SolidType.Butter, 5, 5, 5, 10);
        Container fA = new FluidContainer(FluidType.Milk, 5, 5, 5, 15);
        Container gA = new GasContainer(GasType.Nitrogen, 5, 5, 5, 20);
        
        sA.Add(cA);
        sA.Add(fA);
        sA.Add(gA);
        
        gA.Load(gA.MaxLoad);
        fA.Load(fA.MaxLoad * 0.4);
        try
        {
            // NDE + overfill
            fA.Load(fA.MaxLoad);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex);
        }

        sA.Remove(cA);
        sB.Add(cA);

        Container fB = new FluidContainer(FluidType.HydrochloricAcid, 5, 5, 5, 2);
        // NDE
        fB.Load(fB.MaxLoad * 0.6);
        sA.Replace(fA, fB);
        sA.Replace(sA.IndexOf(fB), fA);
        
        sA.MoveTo(gA, sB);

        foreach (object obj in new object[]
                 {
                     sA,
                     sB,
                     cA,
                     fA,
                     fB,
                     gA
                 })
        {
            Console.WriteLine(obj);
        }
    }
}