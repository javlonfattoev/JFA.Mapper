using JFA.Mapper.Sample.Models;

var user = new User(1, "Csharp", true, new[] { "NET", "Azure" }, "csharp")
{
    Phone = 12, 
    Email = "jfa@fattoev.uz"
};

var config = new JFA.Mapper.MapperConfig();
config.Map("Email", "EmailAddress");
config.Map<User, UserDto>(u => u.Id, dto => dto.Age);

var userDto = user.To<UserDto>(config);

Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(userDto));
