public class FeatureCollection
{
    public List<Features> features {get; set;}
}

public class Features 
{
    public TheProperties properties {get; set;}
}

public class TheProperties
{

    public string place {get; set;}
    public double mag {get; set;}
}