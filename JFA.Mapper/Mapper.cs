using JFA.Mapper;
using System.Reflection;

public static class Mapper
{
    public static T To<T>(this object source, MapperConfig? config = null) where T : class
    {
        var to = Activator.CreateInstance<T>();

        foreach (var sourceProperty in source.GetType().GetProperties())
        {
            var property = sourceProperty.GetToProperty<T>(config);
            if (property?.PropertyType == sourceProperty.PropertyType)
            {
                property.SetValue(to, sourceProperty.GetValue(source));
            }
        }

        return to;
    }

    private static PropertyInfo? GetToProperty<T>(this PropertyInfo source, MapperConfig? config) where T : class
    {
        if (config?.Config.ContainsKey(source.Name) == true)
        {
            return typeof(T).GetProperty(config.Config[source.Name]);
        }
        return typeof(T).GetProperty(source.Name);
    }

    public static MapperConfig Map(this MapperConfig config, string source, string to)
    {
        config.Config.Add(source, to);
        return config;
    }

    public static MapperConfig Map<TSource, TDestination>(this MapperConfig config, Func<TSource, object> from, Func<TDestination, object> to)
    {
        //todo
        return config;
    }
}

