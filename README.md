# JFA.Mapper
Map one object to another

# Steps

> Install package
```PM
NuGet\Install-Package JFA.Mapper -Version <VERSION>
```

#
> Map one object to another
```C#
var user = new User()
{
    Id = 1
    Name = "Csharp", 
    Email = "email@example.com"
};

var userDto = user.To<UserDto>(config);

```
#
> Supports configuration
```C#
var config = new MapperConfig();

// with property name. (fromProperty, toProperty)
config.Map("Email", "EmailAddress");

// or with expression
config.Map<User, UserDto>(u => u.Id, dto => dto.Age);

var userDto = user.To<UserDto>(config);
```
