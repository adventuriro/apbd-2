namespace apbd_tutorial2;

public class Cargo
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public bool IsHazardous { get; set; }

    public Cargo(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public override string ToString()
    {
        return Name + "[" + Weight + " kg]";
    }
}
