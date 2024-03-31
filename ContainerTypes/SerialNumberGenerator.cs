namespace apbd;

public class SerialNumberGenerator
{
    public static readonly SerialNumberGenerator Default = new SerialNumberGenerator();

    private int _id = 0;
    
    public string New(char containerType)
    {
        return $"KON-{containerType}-{++_id}";
    }
}