namespace Priprava_test_01112026;

public class Akvarista
{
    private string _name;
    private Dictionary<WaterType, List<Fish>> _fish;

    public Akvarista(string name)
    {
        Name = name;
        _fish = new Dictionary<WaterType, List<Fish>>();
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool AddFish(Fish fish)
    {
        if (fish is null) return false;
        
        if (!_fish.ContainsKey(fish.WaterType)) _fish[fish.WaterType] = new List<Fish>();
        
        _fish[fish.WaterType].Add(fish);
        return true;
    }

    public List<Fish> GetFishes(WaterType type)
    {
        if (_fish.TryGetValue(type, out var list)) return list;
        return new List<Fish>();
    }

    public List<Fish> this[WaterType waterType]
    {
        get => GetFishes(waterType);
    }
    
    
}