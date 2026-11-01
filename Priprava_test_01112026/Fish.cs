namespace Priprava_test_01112026;

public class Fish
{
    private string _type;
    private string _name;
    private WaterType _waterType;
    
    public Fish(string type, string name, WaterType waterType)
    {
        Type = type;
        Name = name;
        WaterType = waterType;
    }

    public string Type
    {
        get => _type;
        set => _type = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public WaterType WaterType
    {
        get => _waterType;
        set => _waterType = value;
    }
}