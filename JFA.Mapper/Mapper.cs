using System.Linq.Expressions;
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

    public static MapperConfig Map(this MapperConfig config, string source, string to)
    {
        config.Config.Add(source, to);
        return config;
    }

    public static MapperConfig Map<TSource, TDestination>(this MapperConfig config, Expression<Func<TSource, object>> from, Expression<Func<TDestination, object>> to)
    {
        config.Config.Add(GetPropertyName(from), GetPropertyName(to));
        return config;
    }

    internal static PropertyInfo? GetToProperty<T>(this PropertyInfo source, MapperConfig? config) where T : class
    {
        if (config?.Config.ContainsKey(source.Name) == true)
        {
            return typeof(T).GetProperty(config.Config[source.Name]);
        }
        return typeof(T).GetProperty(source.Name);
    }

    internal static string GetPropertyName<T>(Expression<Func<T, object>> property)
    {
        var lambda = (LambdaExpression)property;
        MemberExpression memberExpression;

        if (lambda.Body is UnaryExpression expression)
            memberExpression = (MemberExpression)(expression.Operand);
        else
            memberExpression = (MemberExpression)(lambda.Body);

        return ((PropertyInfo)memberExpression.Member).Name;
    }
}

