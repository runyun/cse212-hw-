public class Person
{
    public readonly string Name;
    public int Turns { get; set; }

    public int InitTurns {get;}

    internal Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
        InitTurns = turns;
    }

    public override string ToString()
    {
        return InitTurns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}