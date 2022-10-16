namespace JFA.Mapper;

public class MapperConfig
{
    internal IDictionary<string, string> Config;

    public MapperConfig() => Config = new Dictionary<string, string>();
}